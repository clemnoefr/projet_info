using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineBiblio.Business;
using WineBiblio.Core.Data;

namespace WineBiblio.Service
{
    public class CustomersService
    {
        private readonly MyDataContext _ctx;

        public CustomersService(MyDataContext ctx)
        {
            _ctx = ctx;
        }

        public Customers Add(Business.Customers Customers)
        {
            var Cus = new Data.DAO.Customers
            {
                mail = Customers.mail,
                last_name = Customers.last_name,
                first_name = Customers.first_name,
                password = Customers.password,
                phone = Customers.phone,

            };
            _ctx.Customers.Add(Cus);
            _ctx.SaveChanges();
            Customers.id_customer = Cus.id_customer;
            return Customers;
        }
        public Customers Login(String mail, String password)
        {
            if (mail == null || password == null)
                return null;
            var found = _ctx.Customers.Where(c => c.mail.ToLower() == mail.ToLower()).FirstOrDefault();
            if (found == null)
                return null;

            string hashed_password = BitConverter.ToString(System.Security.Cryptography.MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(password))).Replace("-", "").ToLower();
            if (found.password.ToLower() != hashed_password)
                return null;

            //select all char to be used in random 
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            //Generate random token
            found.login_cookie = new string(Enumerable.Repeat(chars, 32).Select(s => s[new Random().Next(s.Length)]).ToArray());
            //Update
            _ctx.Customers.Update(found);
            //Push update
            _ctx.SaveChanges();
            //Return FULL client including the login token.
            return (from c in _ctx.Customers where c.id_customer == found.id_customer select new Customers { id_customer = c.id_customer, mail = c.mail, last_name = c.last_name, first_name = c.first_name, password = c.password, phone = c.phone, login_cookie = c.login_cookie }).FirstOrDefault();
        }
        public List<Customers> Get()
        {
            return (from c in _ctx.Customers select new Customers { id_customer = c.id_customer, mail = c.mail, last_name = c.last_name, first_name = c.first_name, password = c.password, phone = c.phone }).ToList();
        }

        public Customers Get(int id)
        {
            return (from c in _ctx.Customers where c.id_customer == id select new Customers { id_customer = c.id_customer, mail = c.mail, last_name = c.last_name, first_name = c.first_name, password = c.password, phone = c.phone }).FirstOrDefault();
        }

        public void Delete(int id)
        {
            var cat = _ctx.Customers.Where(c => c.id_customer == id).FirstOrDefault();
            _ctx.Customers.Remove(cat);
            _ctx.SaveChanges();
        }

        public Customers Edit(int id, Customers customers)
        {
            var customerSelected = _ctx.Customers.Where(c => c.id_customer == id).FirstOrDefault();
            customerSelected.mail = customers.mail;
            customerSelected.last_name = customers.last_name;
            customerSelected.first_name = customers.first_name;
            customerSelected.password = customers.password;
            customerSelected.phone = customers.phone;
            _ctx.Customers.Update(customerSelected);
            _ctx.SaveChanges();
            return customers;
        }
    }
}

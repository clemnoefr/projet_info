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
                address = Customers.address

            };
            _ctx.Customers.Add(Cus);
            _ctx.SaveChanges();
            Customers.id_customer = Cus.id_customer;
            return Customers;
        }

        public List<Customers> Get()
        {
            return (from c in _ctx.Customers select new Customers { id_customer = c.id_customer, mail = c.mail, last_name = c.last_name, first_name = c.first_name, password = c.password, phone = c.phone, address = c.address }).ToList();
        }

        public Customers Get(int id)
        {
            return (from c in _ctx.Customers where c.id_customer == id select new Customers { id_customer = c.id_customer, mail = c.mail, last_name = c.last_name, first_name = c.first_name, password = c.password, phone = c.phone, address = c.address }).FirstOrDefault();
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
            customerSelected.address = customers.address;
            _ctx.Customers.Update(customerSelected);
            _ctx.SaveChanges();
            return customers;
        }
    }
}

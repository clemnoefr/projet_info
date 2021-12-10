using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineBiblio.Business;
using WineBiblio.Core.Data;

namespace WineBiblio.Service
{
    public class CustomerService
    {
        private readonly MyDataContext _ctx;

        public CustomerService(MyDataContext ctx)
        {
            _ctx = ctx;
        }

        public Customer Add(Business.Customer Customer)
        {
            var Cus = new Data.DAO.Customer
            {
                mail = Customer.mail,
                last_name = Customer.last_name,
                first_name = Customer.first_name,
                password = Customer.password,
                phone = Customer.phone,

            };
            _ctx.Customer.Add(Cus);
            _ctx.SaveChanges();
            Customer.id_customer = Cus.id_customer;
            return Customer;
        }

        public List<Customer> Get()
        {
            return (from c in _ctx.Customer select new Customer { id_customer = c.id_customer, mail = c.mail, last_name = c.last_name, first_name = c.first_name, password = c.password, phone = c.phone }).ToList();
        }

        public Customer Get(int id)
        {
            return (from c in _ctx.Customer where c.id_customer == id select new Customer { id_customer = c.id_customer, mail = c.mail, last_name = c.last_name, first_name = c.first_name, password = c.password, phone = c.phone }).FirstOrDefault();
        }

        public void Delete(int id)
        {
            var cat = _ctx.Customer.Where(c => c.id_customer == id).FirstOrDefault();
            _ctx.Customer.Remove(cat);
            _ctx.SaveChanges();
        }

        public void Edit(Customer model)
        {
            var Customer = _ctx.Customer.Where(c => c.id_customer == model.id_customer).FirstOrDefault();
            Customer.mail = model.mail;
            Customer.last_name = model.last_name;
            Customer.first_name = model.first_name;
            Customer.password = model.password;
            Customer.phone = model.phone;

            _ctx.SaveChanges();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineBiblio.Business;
using WineBiblio.Core.Data;

namespace WineBiblio.Service
{
    public class EmployeesService
    {
        private readonly MyDataContext _ctx;

        public EmployeesService(MyDataContext ctx)
        {
            _ctx = ctx;
        }

        public Employees Add(Business.Employees Employees)
        {
            var emp = new Data.DAO.Employees
            {
                mail = Employees.mail,
                last_name = Employees.last_name,
                first_name = Employees.first_name,
                password = Employees.password,
                phone = Employees.phone,

            };
            _ctx.Employees.Add(emp);
            _ctx.SaveChanges();
            Employees.id_employee = emp.id_employee;
            return Employees;
        }

        public List<Employees> Get()
        {
            return (from c in _ctx.Employees select new Employees { id_employee = c.id_employee, mail = c.mail, last_name = c.last_name, first_name = c.first_name, password = c.password, phone = c.phone }).ToList();
        }

        public Employees Get(int id)
        {
            return (from c in _ctx.Employees where c.id_employee == id select new Employees { id_employee = c.id_employee, mail = c.mail, last_name = c.last_name, first_name = c.first_name, password = c.password, phone = c.phone }).FirstOrDefault();
        }

        public void Delete(int id)
        {
            var cat = _ctx.Employees.Where(c => c.id_employee == id).FirstOrDefault();
            _ctx.Employees.Remove(cat);
            _ctx.SaveChanges();
        }

        public Employees Edit(int id, Employees employees)
        {
            var employeeSelected = _ctx.Employees.Where(c => c.id_employee == id).FirstOrDefault();
            employeeSelected.mail = employees.mail;
            employeeSelected.last_name = employees.last_name;
            employeeSelected.first_name = employees.first_name;
            employeeSelected.password = employees.password;
            employeeSelected.phone = employees.phone;
            _ctx.Employees.Update(employeeSelected);
            _ctx.SaveChanges();
            return employees;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineBiblio.Business;
using WineBiblio.Core.Data;

namespace WineBiblio.Service
{
    public class EmployeeService
    {
        private readonly MyDataContext _ctx;

        public EmployeeService(MyDataContext ctx)
        {
            _ctx = ctx;
        }

        public Employee Add(Business.Employee Employee)
        {
            var emp = new Data.DAO.Employee
            {
                mail = Employee.mail,
                last_name = Employee.last_name,
                first_name = Employee.first_name,
                password = Employee.password,
                phone = Employee.phone,

            };
            _ctx.Employee.Add(emp);
            _ctx.SaveChanges();
            Employee.id_employee = emp.id_employee;
            return Employee;
        }

        public List<Employee> Get()
        {
            return (from c in _ctx.Employee select new Employee { id_employee = c.id_employee, mail = c.mail, last_name = c.last_name, first_name = c.first_name, password = c.password, phone = c.phone }).ToList();
        }

        public Employee Get(int id)
        {
            return (from c in _ctx.Employee where c.id_employee == id select new Employee { id_employee = c.id_employee, mail = c.mail, last_name = c.last_name, first_name = c.first_name, password = c.password, phone = c.phone }).FirstOrDefault();
        }

        public void Delete(int id)
        {
            var cat = _ctx.Employee.Where(c => c.id_employee == id).FirstOrDefault();
            _ctx.Employee.Remove(cat);
            _ctx.SaveChanges();
        }

        public Employee Edit(int id, Employee employee)
        {
            var employeeSelected = _ctx.Employee.Where(c => c.id_employee == id).FirstOrDefault();
            employeeSelected.mail = employee.mail;
            employeeSelected.last_name = employee.last_name;
            employeeSelected.first_name = employee.first_name;
            employeeSelected.password = employee.password;
            employeeSelected.phone = employee.phone;
            _ctx.Employee.Update(employeeSelected);
            _ctx.SaveChanges();
            return employee;
        }
    }
}


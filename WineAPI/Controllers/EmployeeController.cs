using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WineBiblio.Business;
using WineBiblio.Core.Data;
using WineBiblio.Service;
using Microsoft.AspNetCore.Mvc;

namespace WineAPI.Controllers
{
    public class EmployeeController : ControllerBase
    {
        private readonly MyDataContext _ctx;
        public EmployeeController(MyDataContext ctx)
        {
            _ctx = ctx;
        }

        [HttpPost("/employees/")]
        public IActionResult Add(Employee employee)
        {
            return Ok(new EmployeeService(_ctx).Add(employee));
        }

        [HttpPost("/employees/login")]
        public IActionResult Login(String mail, String hashed_password)
        {
            var token = new EmployeeService(_ctx).Login(mail, hashed_password);
            return token == null ? Unauthorized() : Ok(token);
        }

        [HttpGet("/employees/")]
        public IActionResult Get()
        {
            return Ok(new EmployeeService(_ctx).Get());
        }

        [HttpGet("/employees/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(new EmployeeService(_ctx).Get(id));
        }
        
        
        [HttpGet("/employees/p/{id}")]
        public IActionResult Get_Protected(int id)
        {
            if (Request.Headers == null)
                return Forbid();
            var login_cookie = this.HttpContext.Request.Headers["Authorization"];

            var employee = _ctx.Employee.Where(c => c.login_cookie == login_cookie).FirstOrDefault();
            if (employee == null)
                return Unauthorized();

            Console.WriteLine("[+] Employee " + employee.first_name + " is accessing protected GetById method!");
            return Ok(new EmployeeService(_ctx).Get(id));
        }

        [HttpDelete("/employees/{id}")]
        public IActionResult Delete(int id)
        {
            new EmployeeService(_ctx).Delete(id);
            return NoContent();
        }

        [HttpPut("/employees/{id}")]
        public IActionResult Update(int id, Employee employee)
        {
            try
            {
                var employeeToUpdate = _ctx.Employee.Where(c => c.id_employee == id).FirstOrDefault();
                if (id != employeeToUpdate.id_employee)
                    return BadRequest();

                if (employeeToUpdate == null)
                    return NotFound();

                return (IActionResult)new EmployeeService(_ctx).Edit(id, employee);
            }

            catch (Exception)
            {
                return new NoContentResult();
            }
        }
    }
}
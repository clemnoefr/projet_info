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
    public class EmployeesController : ControllerBase
    {
        private readonly MyDataContext _ctx;
        public EmployeesController(MyDataContext ctx)
        {
            _ctx = ctx;
        }

        [HttpPost("/employees/")]
        public IActionResult Add(Employees employee)
        {
            return Ok(new EmployeesService(_ctx).Add(employee));
        }

        [HttpGet("/employees/")]
        public IActionResult Get()
        {
            return Ok(new EmployeesService(_ctx).Get());
        }

        [HttpGet("/employees/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(new EmployeesService(_ctx).Get(id));
        }

        [HttpDelete("/employees/{id}")]
        public IActionResult Delete(int id)
        {
            new EmployeesService(_ctx).Delete(id);
            return NoContent();
        }

        [HttpPut("/employees/{id}")]
        public IActionResult Update(int id, Employees employee)
        {
            try
            {
                var employeeToUpdate = _ctx.Employees.Where(c => c.id_employee == id).FirstOrDefault();
                if (id != employeeToUpdate.id_employee)
                    return BadRequest();

                if (employeeToUpdate == null)
                    return NotFound();

                return (IActionResult)new EmployeesService(_ctx).Edit(id, employee);
            }

            catch (Exception)
            {
                return new NoContentResult();
            }
        }
    }
}
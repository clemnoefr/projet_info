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

        [HttpDelete("/employees/{id}")]
        public IActionResult Delete(int id)
        {
            new EmployeeService(_ctx).Delete(id);
            return NoContent();
        }

        [HttpPut("/employees/{id}")]

        public IActionResult Edit(Employee model)
        {
            return Ok(
                /*new EmployeeService(_ctx).Edit(model)*/
                );

        }
    }
}
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
    public class CustomerController : ControllerBase
    {
        private readonly MyDataContext _ctx;
        public CustomerController(MyDataContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet("/customers/")]
        public IActionResult Get()
        {
            return Ok(new CustomerService(_ctx).Get());
        }

        [HttpGet("/customers/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(new CustomerService(_ctx).Get(id));
        }

        [HttpDelete("/customers/{id}")]
        public IActionResult Delete(int id)
        {
            new CustomerService(_ctx).Delete(id);
            return NoContent();
        }

        [HttpPut("/customers/{id}")]

        public IActionResult Edit(Customer model)
        {
            return Ok(
                /*new CustomerService(_ctx).Edit(model)*/
                );

        }
    }
}
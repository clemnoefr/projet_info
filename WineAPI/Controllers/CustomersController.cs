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
    public class CustomersController : ControllerBase
    {
        private readonly MyDataContext _ctx;
        public CustomersController(MyDataContext ctx)
        {
            _ctx = ctx;
        }

        [HttpPost("/customers/")]
        public IActionResult Add(Customers customer)
        {
            return Ok(new CustomersService(_ctx).Add(customer));
        }

        [HttpGet("/customers/")]
        public IActionResult Get()
        {
            return Ok(new CustomersService(_ctx).Get());
        }

        [HttpGet("/customers/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(new CustomersService(_ctx).Get(id));
        }

        [HttpDelete("/customers/{id}")]
        public IActionResult Delete(int id)
        {
            new CustomersService(_ctx).Delete(id);
            return NoContent();
        }

        [HttpPut("/customers/{id}")]
        public IActionResult Update(int id, Customers customer)
        {
            try
            {
                var customerToUpdate = _ctx.Customers.Where(c => c.id_customer == id).FirstOrDefault();
                if (id != customerToUpdate.id_customer)
                    return BadRequest();

                if (customerToUpdate == null)
                    return NotFound();

                return (IActionResult)new CustomersService(_ctx).Edit(id, customer);
            }

            catch (Exception)
            {
                return new NoContentResult();
            }
        }
    }
}
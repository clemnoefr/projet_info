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

        [HttpPost("/customers/")]
        public IActionResult Add(Customer customer)
        {
            return Ok(new CustomerService(_ctx).Add(customer));
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
        public IActionResult Update(int id, Customer customer)
        {
            try
            {
                var customerToUpdate = _ctx.Category.Where(c => c.id_category == id).FirstOrDefault();
                if (id != customerToUpdate.id_category)
                    return BadRequest();

                if (customerToUpdate == null)
                    return NotFound();

                return (IActionResult)new CustomerService(_ctx).Edit(id, customer);
            }

            catch (Exception)
            {
                return new NoContentResult();
            }
        }
    }
}
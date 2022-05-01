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

        [HttpPost("/customers/login")]
        public IActionResult Login(String mail, String password)
        {
            var token = new CustomersService(_ctx).Login(mail, password);
            return token == null ? Unauthorized() : Ok(token);
        }

        // Sample (Get customer info from token)
        //[HttpGet("/customers/p/{id}")]
        //public IActionResult Get_Protected(int id)
        //{
        //    if (Request.Headers == null)
        //        return Forbid();
        //    var login_cookie = this.HttpContext.Request.Headers["Authorization"];

        //    var customer = _ctx.Customers.Where(c => c.login_cookie == login_cookie).FirstOrDefault();
        //    if (customer == null)
        //        return Unauthorized();

        //    Console.WriteLine("[+] Customer " + customer.first_name + " is accessing protected GetById method!");
        //    return Ok(new CustomersService(_ctx).Get(id));
        //}

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
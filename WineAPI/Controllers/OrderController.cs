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
    public class OrderController : ControllerBase
    {
        private readonly MyDataContext _ctx;
        public OrderController(MyDataContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet("/orders/")]
        public IActionResult Get()
        {
            return Ok(new OrderService(_ctx).Get());
        }

        [HttpGet("/orders/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(new OrderService(_ctx).Get(id));
        }

        [HttpDelete("/orders/{id}")]
        public IActionResult Delete(int id)
        {
            new OrderService(_ctx).Delete(id);
            return NoContent();
        }

        [HttpPut("/orders/{id}")]

        public IActionResult Edit(Order model)
        {
            return Ok(
          /*    new OrderService(_ctx).Edit(model)
           */    
               );

        }
    }
}
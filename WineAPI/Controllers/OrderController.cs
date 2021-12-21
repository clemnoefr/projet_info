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

        [HttpPost("/orders/")]
        public IActionResult Add(Order order)
        {
            return Ok(new OrderService(_ctx).Add(order));
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
        public IActionResult Update(int id, Order order)
        {
            try
            {
                var orderToUpdate = _ctx.Order.Where(c => c.id_order == id).FirstOrDefault();
                if (id != orderToUpdate.id_order)
                    return BadRequest();

                if (orderToUpdate == null)
                    return NotFound();

                return (IActionResult)new OrderService(_ctx).Edit(id, order);
            }

            catch (Exception)
            {
                return new NoContentResult();
            }
        }
    }
}
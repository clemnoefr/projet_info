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
    public class OrdersController : ControllerBase
    {
        private readonly MyDataContext _ctx;
        public OrdersController(MyDataContext ctx)
        {
            _ctx = ctx;
        }

        [HttpPost("/orders/")]
        public IActionResult Add(Orders order)
        {
            return Ok(new OrdersService(_ctx).Add(order));
        }

        [HttpGet("/orders/")]
        public IActionResult Get()
        {
            return Ok(new OrdersService(_ctx).Get());
        }

        [HttpGet("/orders/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(new OrdersService(_ctx).Get(id));
        }

        [HttpDelete("/orders/{id}")]
        public IActionResult Delete(int id)
        {
            new OrdersService(_ctx).Delete(id);
            return NoContent();
        }

        [HttpPut("/orders/{id}")]
        public IActionResult Update(int id, Orders order)
        {
            try
            {
                var orderToUpdate = _ctx.Orders.Where(c => c.id_order == id).FirstOrDefault();
                if (id != orderToUpdate.id_order)
                    return BadRequest();

                if (orderToUpdate == null)
                    return NotFound();

                return (IActionResult)new OrdersService(_ctx).Edit(id, order);
            }

            catch (Exception)
            {
                return new NoContentResult();
            }
        }
    }
}
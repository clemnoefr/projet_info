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
    public class HistoryOrderController : ControllerBase
    {
        private readonly MyDataContext _ctx;
        public HistoryOrderController(MyDataContext ctx)
        {
            _ctx = ctx;
        }

        [HttpPost("/historyOrder/")]
        public IActionResult Add(History_Order historyOrder)
        {
            return Ok(new HistoryOrderService(_ctx).Add(historyOrder));
        }

        [HttpGet("/historyOrder/")]
        public IActionResult Get()
        {
            return Ok(new HistoryOrderService(_ctx).Get());
        }

        [HttpGet("/historyOrder/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(new HistoryOrderService(_ctx).Get(id));
        }

        [HttpDelete("/historyOrder/{id}")]
        public IActionResult Delete(int id)
        {
            new HistoryOrderService(_ctx).Delete(id);
            return NoContent();
        }

        [HttpPut("/historyOrder/{id}")]
        public IActionResult Update(int id, History_Order historyOrder)
        {
            try
            {
                var historyOrderToUpdate = _ctx.History_Order.Where(c => c.id_history_order== id).FirstOrDefault();
                if (id != historyOrderToUpdate.id_history_order)
                    return BadRequest();

                if (historyOrderToUpdate == null)
                    return NotFound();

                return (IActionResult)new HistoryOrderService(_ctx).Edit(id, historyOrder);
            }

            catch (Exception)
            {
                return new NoContentResult();
            }
        }
    }
}
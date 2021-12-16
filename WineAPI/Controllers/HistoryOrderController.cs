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

        public IActionResult Edit(HistoryOrder model)
        {
            return Ok(
                /*new HistoryOrderService(_ctx).Edit(model)*/
                 );

        }
    }
}
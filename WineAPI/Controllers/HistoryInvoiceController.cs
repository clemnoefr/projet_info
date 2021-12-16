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
    public class HistoryInvoiceController : ControllerBase
    {
        private readonly MyDataContext _ctx;
        public HistoryInvoiceController(MyDataContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet("/historyInvoice/")]
        public IActionResult Get()
        {
            return Ok(new HistoryInvoiceService(_ctx).Get());
        }

        [HttpGet("/historyInvoice/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(new HistoryInvoiceService(_ctx).Get(id));
        }

        [HttpDelete("/historyInvoice/{id}")]
        public IActionResult Delete(int id)
        {
            new HistoryInvoiceService(_ctx).Delete(id);
            return NoContent();
        }

        [HttpPut("/historyInvoice/{id}")]

        public IActionResult Edit(HistoryInvoice model)
        {
            return Ok(
                /*new HistoryInvoiceService(_ctx).Edit(model)*/
                );

        }
    }
}
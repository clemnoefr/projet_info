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

        [HttpPost("/historyInvoice/")]
        public IActionResult Add(History_Invoice historyInvoice)
        {
            return Ok(new HistoryInvoiceService(_ctx).Add(historyInvoice));
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
        public IActionResult Update(int id, History_Invoice historyInvoice)
        {
            try
            {
                var historyInvoiceToUpdate = _ctx.History_Invoice.Where(c => c.id_history_invoice == id).FirstOrDefault();
                if (id != historyInvoiceToUpdate.id_history_invoice)
                    return BadRequest();

                if (historyInvoiceToUpdate == null)
                    return NotFound();

                return (IActionResult)new HistoryInvoiceService(_ctx).Edit(id, historyInvoice);
            }

            catch (Exception)
            {
                return new NoContentResult();
            }
        }
    }
}
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
    public class InvoicesController : ControllerBase
    {
        private readonly MyDataContext _ctx;
        public InvoicesController(MyDataContext ctx)
        {
            _ctx = ctx;
        }

        [HttpPost("/invoices/")]
        public IActionResult Add(Invoices invoice)
        {
            return Ok(new InvoicesService(_ctx).Add(invoice));
        }


        [HttpGet("/invoices/")]
        public IActionResult Get()
        {
            return Ok(new InvoicesService(_ctx).Get());
        }

        [HttpGet("/invoices/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(new InvoicesService(_ctx).Get(id));
        }

        [HttpDelete("/invoices/{id}")]
        public IActionResult Delete(int id)
        {
            new InvoicesService(_ctx).Delete(id);
            return NoContent();
        }

        [HttpPut("/invoices/{id}")]
        public IActionResult Update(int id, Invoices invoice)
        {
            try
            {
                var invoiceToUpdate = _ctx.Invoices.Where(c => c.id_invoice == id).FirstOrDefault();
                if (id != invoiceToUpdate.id_invoice)
                    return BadRequest();

                if (invoiceToUpdate == null)
                    return NotFound();

                return (IActionResult)new InvoicesService(_ctx).Edit(id, invoice);
            }

            catch (Exception)
            {
                return new NoContentResult();
            }
        }
    }
}
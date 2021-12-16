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
    public class InvoiceController : ControllerBase
    {
        private readonly MyDataContext _ctx;
        public InvoiceController(MyDataContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet("/invoices/")]
        public IActionResult Get()
        {
            return Ok(new InvoiceService(_ctx).Get());
        }

        [HttpGet("/invoices/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(new InvoiceService(_ctx).Get(id));
        }

        [HttpDelete("/invoices/{id}")]
        public IActionResult Delete(int id)
        {
            new InvoiceService(_ctx).Delete(id);
            return NoContent();
        }

        [HttpPut("/invoices/{id}")]

        public IActionResult Edit(Invoice model)
        {
            return Ok(
                /*new InvoiceService(_ctx).Edit(model)*/
                 );

        }
    }
}
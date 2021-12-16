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
    public class SupplierController : ControllerBase
    {
        private readonly MyDataContext _ctx;
        public SupplierController(MyDataContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet("/suppliers/")]
        public IActionResult Get()
        {
            return Ok(new SupplierService(_ctx).Get());
        }

        [HttpGet("/suppliers/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(new SupplierService(_ctx).Get(id));
        }

        [HttpDelete("/suppliers/{id}")]
        public IActionResult Delete(int id)
        {
            new SupplierService(_ctx).Delete(id);
            return NoContent();
        }

        [HttpPut("/suppliers/{id}")]

        public IActionResult Edit(Supplier model)
        {
            return Ok(
                /*new SupplierService(_ctx).Edit(model)*/
                );

        }
    }
}
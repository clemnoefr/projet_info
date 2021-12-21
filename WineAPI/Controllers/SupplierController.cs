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

        [HttpPost("/suppliers/")]
        public IActionResult Add(Supplier supplier)
        {
            return Ok(new SupplierService(_ctx).Add(supplier));
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
        public IActionResult Update(int id, Supplier supplier)
        {
            try
            {
                var supplierToUpdate = _ctx.Supplier.Where(c => c.id_supplier == id).FirstOrDefault();
                if (id != supplierToUpdate.id_supplier)
                    return BadRequest();

                if (supplierToUpdate == null)
                    return NotFound();

                return (IActionResult)new SupplierService(_ctx).Edit(id, supplier);
            }

            catch (Exception)
            {
                return new NoContentResult();
            }
        }
    }
}
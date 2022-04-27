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
    public class SuppliersController : ControllerBase
    {
        private readonly MyDataContext _ctx;
        public SuppliersController(MyDataContext ctx)
        {
            _ctx = ctx;
        }

        [HttpPost("/suppliers/")]
        public IActionResult Add(Suppliers supplier)
        {
            return Ok(new SuppliersService(_ctx).Add(supplier));
        }

        [HttpGet("/suppliers/")]
        public IActionResult Get()
        {
            return Ok(new SuppliersService(_ctx).Get());
        }

        [HttpGet("/suppliers/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(new SuppliersService(_ctx).Get(id));
        }

        [HttpDelete("/suppliers/{id}")]
        public IActionResult Delete(int id)
        {
            new SuppliersService(_ctx).Delete(id);
            return NoContent();
        }

        [HttpPut("/suppliers/{id}")]
        public IActionResult Update(int id, Suppliers supplier)
        {
            try
            {
                var supplierToUpdate = _ctx.Suppliers.Where(c => c.id_supplier == id).FirstOrDefault();
                if (id != supplierToUpdate.id_supplier)
                    return BadRequest();

                if (supplierToUpdate == null)
                    return NotFound();

                return (IActionResult)new SuppliersService(_ctx).Edit(id, supplier);
            }

            catch (Exception)
            {
                return new NoContentResult();
            }
        }
    }
}
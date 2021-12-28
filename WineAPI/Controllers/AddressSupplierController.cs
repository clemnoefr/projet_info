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
    [ApiController]
    public class AddressSupplierController : ControllerBase
    {
        private readonly MyDataContext _ctx;

        public AddressSupplierController(MyDataContext ctx)
        {
            _ctx = ctx;
        }

        [HttpPost("/addressSupplier/")]
        public IActionResult Add(Address_Supplier addressSupplier)
        {
            return Ok(new AddressSupplierService(_ctx).Add(addressSupplier));
        }

        [HttpGet("/addressSupplier/")]
        public IActionResult Get()
        {
            return Ok(new AddressSupplierService(_ctx).Get());
        }

        [HttpGet("/addressSupplier/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(new AddressSupplierService(_ctx).Get(id));
        }

        [HttpDelete("/addressSupplier/{id}")]
        public IActionResult Delete(int id)
        {
            new AddressSupplierService(_ctx).Delete(id);
            return NoContent();
        }

        [HttpPut("/addressSupplier/{id}")]
        public IActionResult Update(int id, Address_Supplier addressSupplier)
        {
            try
            {
                var addressSupplierToUpdate = _ctx.Address_Supplier.Where(c => c.id_address_supplier == id).FirstOrDefault();
                if (id != addressSupplierToUpdate.id_address_supplier)
                    return BadRequest();

                if (addressSupplierToUpdate == null)
                    return NotFound();

                return (IActionResult)new AddressSupplierService(_ctx).Edit(id, addressSupplier);
            }

            catch (Exception)
            {
                return new NoContentResult();
            }
        }
    }
}
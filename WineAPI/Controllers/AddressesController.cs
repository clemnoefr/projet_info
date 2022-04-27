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
    public class AddressesController : ControllerBase
    {
        private readonly MyDataContext _ctx;

        public AddressesController(MyDataContext ctx)
        {
            _ctx = ctx;
        }
        
        [HttpPost("/addresses/")]
        public IActionResult Add(Addresses address)
        {
            return Ok(new AddressesService(_ctx).Add(address));
        }

        [HttpGet("/addresses/")]
        public IActionResult Get()
        {
            return Ok(new AddressesService(_ctx).Get());
        }

        [HttpGet("/addresses/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(new AddressesService(_ctx).Get(id));
        }

        [HttpDelete("/addresses/{id}")]
        public IActionResult Delete(int id)
        {
            new AddressesService(_ctx).Delete(id);
            return NoContent();
        }

        [HttpPut("/addresses/{id}")]
        public IActionResult Update(int id, Addresses address)
        {
            try
            {
                var addressToUpdate = _ctx.Addresses.Where(c => c.id_address == id).FirstOrDefault();
                if (id != addressToUpdate.id_address)
                    return BadRequest();

                if (addressToUpdate == null)
                    return NotFound();

                return (IActionResult)new AddressesService(_ctx).Edit(id, address);
            }

            catch (Exception)
            {
                return new NoContentResult();
            }
        }
    }
}

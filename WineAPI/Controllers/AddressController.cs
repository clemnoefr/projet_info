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
    public class AddressController : ControllerBase
    {
        private readonly MyDataContext _ctx;

        public AddressController(MyDataContext ctx)
        {
            _ctx = ctx;
        }
        
        [HttpPost("/addresses/")]
        public IActionResult Add(Address address)
        {
            return Ok(new AddressService(_ctx).Add(address));
        }

        [HttpGet("/addresses/")]
        public IActionResult Get()
        {
            return Ok(new AddressService(_ctx).Get());
        }

        [HttpGet("/addresses/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(new AddressService(_ctx).Get(id));
        }

        [HttpDelete("/addresses/{id}")]
        public IActionResult Delete(int id)
        {
            new AddressService(_ctx).Delete(id);
            return NoContent();
        }

        [HttpPut("/addresses/{id}")]
        public IActionResult Update(int id, Address address)
        {
            try
            {
                var addressToUpdate = _ctx.Address.Where(c => c.id_address == id).FirstOrDefault();
                if (id != addressToUpdate.id_address)
                    return BadRequest();

                if (addressToUpdate == null)
                    return NotFound();

                return (IActionResult)new AddressService(_ctx).Edit(id, address);
            }

            catch (Exception)
            {
                return new NoContentResult();
            }
        }
    }
}

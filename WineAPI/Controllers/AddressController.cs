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
    public class AddressController : ControllerBase
    {
        private readonly MyDataContext _ctx;

        public AddressController(MyDataContext ctx)
        {
            _ctx = ctx;
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

        public IActionResult Edit(Address model)
        {
            return Ok(
                /*new AddressService(_ctx).Update(model)*/
                );

        }
    }
}
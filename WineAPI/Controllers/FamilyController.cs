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
    public class FamilyController : ControllerBase
    {
        private readonly MyDataContext _ctx;

        public FamilyController(MyDataContext ctx)
        {
            _ctx = ctx;
        }
        
        [HttpPost("/families/")]
        public IActionResult Add(Family family)
        {
            return Ok(new FamilyService(_ctx).Add(family));
        }

        [HttpGet("/families/")]
        public IActionResult Get()
        {
            return Ok(new FamilyService(_ctx).Get());
        }

        [HttpGet("/families/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(new FamilyService(_ctx).Get(id));
        }

        [HttpDelete("/families/{id}")]
        public IActionResult Delete(int id)
        {
            new FamilyService(_ctx).Delete(id);
            return NoContent();
        }

        [HttpPut("/families/{id}")]
        public IActionResult Update(int id, Family family)
        {
            try
            {
                var familyToUpdate = _ctx.Address.Where(c => c.id_family == id).FirstOrDefault();
                if (id != familyToUpdate.id_family)
                    return BadRequest();

                if (familyToUpdate == null)
                    return NotFound();

                return (IActionResult)new FamilyService(_ctx).Edit(id, family);
            }

            catch (Exception)
            {
                return new NoContentResult();
            }
        }
    }
}

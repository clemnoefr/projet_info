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
    public class FamiliesController : ControllerBase
    {
        private readonly MyDataContext _ctx;

        public FamiliesController(MyDataContext ctx)
        {
            _ctx = ctx;
        }
        
        [HttpPost("/families/")]
        public IActionResult Add(Families family)
        {
            return Ok(new FamiliesService(_ctx).Add(family));
        }

        [HttpGet("/families/")]
        public IActionResult Get()
        {
            return Ok(new FamiliesService(_ctx).Get());
        }

        [HttpGet("/families/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(new FamiliesService(_ctx).Get(id));
        }

        [HttpDelete("/families/{id}")]
        public IActionResult Delete(int id)
        {
            new FamiliesService(_ctx).Delete(id);
            return NoContent();
        }

        [HttpPut("/families/{id}")]
        public IActionResult Update(int id, Families family)
        {
            try
            {
                var familyToUpdate = _ctx.Family.Where(c => c.id_family == id).FirstOrDefault();
                if (id != familyToUpdate.id_family)
                    return BadRequest();

                if (familyToUpdate == null)
                    return NotFound();

                return (IActionResult)new FamiliesService(_ctx).Edit(id, family);
            }

            catch (Exception)
            {
                return new NoContentResult();
            }
        }
    }
}

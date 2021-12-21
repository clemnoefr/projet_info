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
    public class ContainController : ControllerBase
    {
        private readonly MyDataContext _ctx;
        public ContainController(MyDataContext ctx)
        {
            _ctx = ctx;
        }

        [HttpPost("/contain/")]
        public IActionResult Add(Contain contain)
        {
            return Ok(new ContainService(_ctx).Add(contain));
        }

        [HttpGet("/contain/")]
        public IActionResult Get()
        {
            return Ok(new ContainService(_ctx).Get());
        }

        [HttpGet("/contain/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(new ContainService(_ctx).Get(id));
        }

        [HttpDelete("/contain/{id}")]
        public IActionResult Delete(int id)
        {
            new ContainService(_ctx).Delete(id);
            return NoContent();
        }

        [HttpPut("/contain/{id}")]

        public IActionResult Update(int id, Contain contain)
        {
            try
            {
                var containToUpdate = _ctx.Contain.Where(c => c.id_contain == id).FirstOrDefault();
                if (id != containToUpdate.id_contain)
                    return BadRequest();

                if (containToUpdate == null)
                    return NotFound();

                return (IActionResult)new ContainService(_ctx).Edit(id, contain);
            }

            catch (Exception)
            {
                return new NoContentResult();
            }
        }
    }
}
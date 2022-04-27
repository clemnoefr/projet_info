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
    public class TypessController : ControllerBase
    {
        private readonly MyDataContext _ctx;

        public TypessController(MyDataContext ctx)
        {
            _ctx = ctx;
        }
        
        [HttpPost("/types/")]
        public IActionResult Add(Types type)
        {
            return Ok(new TypesService(_ctx).Add(type));
        }

        [HttpGet("/types/")]
        public IActionResult Get()
        {
            return Ok(new TypesService(_ctx).Get());
        }

        [HttpGet("/types/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(new TypesService(_ctx).Get(id));
        }

        [HttpDelete("/types/{id}")]
        public IActionResult Delete(int id)
        {
            new TypesService(_ctx).Delete(id);
            return NoContent();
        }

        [HttpPut("/types/{id}")]
        public IActionResult Update(int id, Types typ)
        {
            try
            {
                var typeToUpdate = _ctx.Types.Where(c => c.id_type == id).FirstOrDefault();
                if (id != typeToUpdate.id_type)
                    return BadRequest();

                if (typeToUpdate == null)
                    return NotFound();

                return (IActionResult)new TypesService(_ctx).Edit(id, typ);
            }

            catch (Exception)
            {
                return new NoContentResult();
            }
        }
    }
}

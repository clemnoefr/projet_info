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
    public class TypeController : ControllerBase
    {
        private readonly MyDataContext _ctx;

        public TypeController(MyDataContext ctx)
        {
            _ctx = ctx;
        }
        
        [HttpPost("/types/")]
        public IActionResult Add(Type type)
        {
            return Ok(new TypeService(_ctx).Add(type));
        }

        [HttpGet("/types/")]
        public IActionResult Get()
        {
            return Ok(new TypeService(_ctx).Get());
        }

        [HttpGet("/types/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(new TypeService(_ctx).Get(id));
        }

        [HttpDelete("/types/{id}")]
        public IActionResult Delete(int id)
        {
            new TypeService(_ctx).Delete(id);
            return NoContent();
        }

        [HttpPut("/types/{id}")]
        public IActionResult Update(int id, Type typ)
        {
            try
            {
                var typeToUpdate = _ctx.Type.Where(c => c.id_type == id).FirstOrDefault();
                if (id != typeToUpdate.id_type)
                    return BadRequest();

                if (typeToUpdate == null)
                    return NotFound();

                return (IActionResult)new TypeService(_ctx).Edit(id, typ);
            }

            catch (Exception)
            {
                return new NoContentResult();
            }
        }
    }
}

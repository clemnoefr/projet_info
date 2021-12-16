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

        public IActionResult Edit(Contain model)
        {
            return Ok(
               /* new ContainService(_ctx).Edit(model)*/
                );

        }
    }
}
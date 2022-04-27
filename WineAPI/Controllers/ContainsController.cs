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
    public class ContainsController : ControllerBase
    {
        private readonly MyDataContext _ctx;
        public ContainsController(MyDataContext ctx)
        {
            _ctx = ctx;
        }

        [HttpPost("/contain/")]
        public IActionResult Add(Contains contain)
        {
            return Ok(new ContainsService(_ctx).Add(contain));
        }

        [HttpGet("/contain/")]
        public IActionResult Get()
        {
            return Ok(new ContainsService(_ctx).Get());
        }

        [HttpGet("/contain/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(new ContainsService(_ctx).Get(id));
        }



        [HttpPut("/contain/{id}")]

        public IActionResult Update(int id, Contains contain)
        {
            try
            {
                var containToUpdate = _ctx.Contains.Where(c => c.id_order == id).FirstOrDefault();
                if (id != containToUpdate.id_order)
                    return BadRequest();

                if (containToUpdate == null)
                    return NotFound();

                return (IActionResult)new ContainsService(_ctx).Edit(id, contain);
            }

            catch (Exception)
            {
                return new NoContentResult();
            }
        }
    }
}
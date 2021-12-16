using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WineBiblio.Business;
using WineBiblio.Core.Data;
using WineBiblio.Service;
using Microsoft.AspNetCore.Mvc;

namespace WineAPI.API.Controllers
{

    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly MyDataContext _ctx;

        public CategoryController(MyDataContext ctx)
        {
            _ctx = ctx;
        }


        [HttpGet("/categories/")]
        public IActionResult Get()
        {
            return Ok(new CategoryService(_ctx).Get());
        }

        [HttpGet("/categories/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(new CategoryService(_ctx).Get(id));
        }

        [HttpDelete("/categories/{id}")]
        public IActionResult Delete(int id)
        {
            new CategoryService(_ctx).Delete(id);
            return NoContent();
        }

        [HttpPut("/categories/{id}")]

        public IActionResult Modif(Category model)
        {
            return Ok(
                /*new CategoryService(_ctx).Edit(model)*/
                );

        }
    }
}

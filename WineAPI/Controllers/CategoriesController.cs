using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WineBiblio.Business;
using WineBiblio.Core.Data;
using WineBiblio.Service;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity.Infrastructure;

namespace WineAPI.API.Controllers
{

    public class CategoriesController : ControllerBase

    {
        private readonly MyDataContext _ctx;

        public CategoriesController(MyDataContext ctx)
        {
            _ctx = ctx;
        }

        [HttpPost("/categories/")]
        public IActionResult Add(Categories category)
        {
            return Ok(new CategoriesService(_ctx).Add(category));
        }


        [HttpGet("/categories/")]
        public IActionResult Get()
        {
            return Ok(new CategoriesService(_ctx).Get());
        }

        [HttpGet("/categories/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(new CategoriesService(_ctx).Get(id));
        }

        [HttpDelete("/categories/{id}")]
        public IActionResult Delete(int id)
        {
            new CategoriesService(_ctx).Delete(id);
            return NoContent();
        }

        [HttpPut("/categories/{id}")]
        public IActionResult Update(int id, Categories category)
        {
         try
            {
                var categoryToUpdate = _ctx.Categories.Where(c => c.id_category == id).FirstOrDefault();
                if (id != categoryToUpdate.id_category)
                    return BadRequest();

                if (categoryToUpdate == null)
                    return NotFound();

                return (IActionResult)new CategoriesService(_ctx).Edit(id, category);
            }
                         
            catch (Exception)
            {
                return new NoContentResult();
            }
        }

    }
}

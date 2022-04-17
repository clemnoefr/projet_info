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

    public class CategoryController : ControllerBase

    {
        private readonly MyDataContext _ctx;

        public CategoryController(MyDataContext ctx)
        {
            _ctx = ctx;
        }

        [HttpPost("/categories/")]
        public IActionResult Add(Category category)
        {
            return Ok(new CategoryService(_ctx).Add(category));
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
        public IActionResult Update(int id, Category category)
        {
         try
            {
                var categoryToUpdate = _ctx.Category.Where(c => c.id_category == id).FirstOrDefault();
                if (id != categoryToUpdate.id_category)
                    return BadRequest();

                if (categoryToUpdate == null)
                    return NotFound();

                return (IActionResult)new CategoryService(_ctx).Edit(id, category);
            }
                         
            catch (Exception)
            {
                return new NoContentResult();
            }
        }

    }
}

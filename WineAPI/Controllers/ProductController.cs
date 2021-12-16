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
    public class ProductController : ControllerBase
    {
        private readonly MyDataContext _ctx;
        public ProductController(MyDataContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet("/products/")]
        public IActionResult Get()
        {
            return Ok(new ProductService(_ctx).Get());
        }

        [HttpGet("/products/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(new ProductService(_ctx).Get(id));
        }

        [HttpDelete("/products/{id}")]
        public IActionResult Delete(int id)
        {
            new ProductService(_ctx).Delete(id);
            return NoContent();
        }

        [HttpPut("/products/{id}")]

        public IActionResult Edit(Product model)
        {
            return Ok(
                /*new ProductService(_ctx).Edit(model)*/
                );

        }
    }
}
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
    public class ProductsController : ControllerBase
    {
        private readonly MyDataContext _ctx;
        public ProductsController(MyDataContext ctx)
        {
            _ctx = ctx;
        }

        [HttpPost("/products/")]
        public IActionResult Add(Products product)
        {
            return Ok(new ProductsService(_ctx).Add(product));
        }

        [HttpGet("/products/")]
        public IActionResult Get()
        {
            return Ok(new ProductsService(_ctx).Get());
        }

        [HttpGet("/products/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(new ProductsService(_ctx).Get(id));
        }

        [HttpDelete("/products/{id}")]
        public IActionResult Delete(int id)
        {
            new ProductsService(_ctx).Delete(id);
            return NoContent();
        }

        [HttpPut("/products/{id}")]
        public IActionResult Update(int id, Products product)
        {
            try
            {
                var productToUpdate = _ctx.Products.Where(c => c.id_product == id).FirstOrDefault();
                if (id != productToUpdate.id_product)
                    return BadRequest();

                if (productToUpdate == null)
                    return NotFound();

                return (IActionResult) new ProductsService(_ctx).Edit(id, product);
            }

            catch (Exception)
            {
                return new NoContentResult();
            }
        }
    }
}
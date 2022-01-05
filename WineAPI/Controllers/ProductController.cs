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

        [HttpPost("/products/")]
        public IActionResult Add(Product product)
        {
            return Ok(new ProductService(_ctx).Add(product));
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
        public IActionResult Update(int id, Product product)
        {
            try
            {
                var productToUpdate = _ctx.Product.Where(c => c.id_product == id).FirstOrDefault();
                if (id != productToUpdate.id_product)
                    return BadRequest();

                if (productToUpdate == null)
                    return NotFound();

                return (IActionResult) new ProductService(_ctx).Edit(id, product);
            }

            catch (Exception)
            {
                return new NoContentResult();
            }
        }
    }
}
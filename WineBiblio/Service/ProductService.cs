using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineBiblio.Business;
using WineBiblio.Core.Data;

namespace WineBiblio.Service
{
    public class ProductService
    {
        private readonly MyDataContext _ctx;

        public ProductService(MyDataContext ctx)
        {
            _ctx = ctx;
        }

        public Product Add(Business.Product Product)
        {
            var Prod = new Data.DAO.Product
            {
                name = Product.name,
                description = Product.description,
                reference = Product.reference,
                bottled_year = Product.bottled_year,
                picture = Product.picture,
                origine = Product.origine,
                quantity_stock = Product.quantity_stock
            };
            _ctx.Product.Add(Prod);
            _ctx.SaveChanges();
            Product.id_product = Prod.id_product;
            return Product;
        }

        public List<Product> Get()
        {
            return (from c in _ctx.Product select new Product { id_product = c.id_product, name = c.name, description = c.description, reference = c.reference, bottled_year = c.bottled_year, picture = c.picture, origine = c.origine, quantity_stock = c.quantity_stock }).ToList();
        }

        public Product Get(int id)
        {
            return (from c in _ctx.Product where c.id_product == id select new Product { id_product = c.id_product, name = c.name, description = c.description, reference = c.reference, bottled_year = c.bottled_year, picture = c.picture, origine = c.origine, quantity_stock = c.quantity_stock }).FirstOrDefault();
        }

        public void Delete(int id)
        {
            var cat = _ctx.Product.Where(c => c.id_product == id).FirstOrDefault();
            _ctx.Product.Remove(cat);
            _ctx.SaveChanges();
        }

        public void Edit(Product model)
        {
            var Product = _ctx.Product.Where(c => c.id_product == model.id_product).FirstOrDefault();
            Product.name = model.name;
            Product.description = model.description;
            Product.reference = model.reference;
            Product.bottled_year = model.bottled_year;
            Product.picture = model.picture;
            Product.origine = model.origine;
            Product.quantity_stock = model.quantity_stock;
            _ctx.SaveChanges();
        }
    }
}

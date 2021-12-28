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
                quantity_stock = Product.quantity_stock,
                id_address_supplier = Product.id_address_supplier,
                id_category = Product.id_category
                
            };
            _ctx.Product.Add(Prod);
            _ctx.SaveChanges();
            Product.id_product = Prod.id_product;
            return Product;
        }

        public List<Product> Get()
        {
            return (from c in _ctx.Product select new Product { id_product = c.id_product, name = c.name, description = c.description, reference = c.reference, bottled_year = c.bottled_year, picture = c.picture, origine = c.origine, quantity_stock = c.quantity_stock, id_address_supplier = c.id_address_supplier, id_category = c.id_category }).ToList();
        }

        public Product Get(int id)
        {
            return (from c in _ctx.Product where c.id_product == id select new Product { id_product = c.id_product, name = c.name, description = c.description, reference = c.reference, bottled_year = c.bottled_year, picture = c.picture, origine = c.origine, quantity_stock = c.quantity_stock, id_address_supplier = c.id_address_supplier, id_category = c.id_category }).FirstOrDefault();
        }

        public void Delete(int id)
        {
            var cat = _ctx.Product.Where(c => c.id_product == id).FirstOrDefault();
            _ctx.Product.Remove(cat);
            _ctx.SaveChanges();
        }

        public Product Edit(int id, Product product)
        {
            var productSelected = _ctx.Product.Where(c => c.id_product == id).FirstOrDefault();
            productSelected.name = product.name;
            productSelected.description = product.description;
            productSelected.reference = product.reference;
            productSelected.bottled_year = product.bottled_year;
            productSelected.picture = product.picture;
            productSelected.origine = product.origine;
            productSelected.quantity_stock = product.quantity_stock;
            productSelected.id_address_supplier = product.id_address_supplier;
            productSelected.id_category = product.id_category;
            _ctx.Product.Update(productSelected);
            _ctx.SaveChanges();
            return product;
        }
    }
}

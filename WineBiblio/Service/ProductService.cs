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
                product_name = Product.product_name,
                description = Product.description,
                price_ht = Product.price_ht,
                reference = Product.reference,
                bottled_year = Product.bottled_year,
                picture = Product.picture,
                origine = Product.origine,
                stock = Product.stock,
                supplier_price = Product.supplier_price,
                price_carton = Product.price_carton,
                id_supplier = Product.id_supplier,
                id_category = Product.id_category,
                id_family = Product.id_family
                
            };
            _ctx.Product.Add(Prod);
            _ctx.SaveChanges();
            Product.id_product = Prod.id_product;
            return Product;
        }

        public List<Product> Get()
        {
            return (from c in _ctx.Product select new Product { id_product = c.id_product, product_name = c.product_name, description = c.description, price_ht=c.price_ht, reference = c.reference, bottled_year = c.bottled_year, picture = c.picture, origine = c.origine, stock = c.stock,supplier_price = c.supplier_price, price_carton = c.price_carton, id_supplier = c.id_supplier, id_category = c.id_category, id_family = c.id_family }).ToList();
        }

        public Product Get(int id)
        {
            return (from c in _ctx.Product where c.id_product == id select new Product { id_product = c.id_product, product_name = c.product_name, description = c.description, price_ht = c.price_ht, reference = c.reference, bottled_year = c.bottled_year, picture = c.picture, origine = c.origine, stock = c.stock, supplier_price = c.supplier_price, price_carton = c.price_carton, id_supplier = c.id_supplier, id_category = c.id_category, id_family = c.id_family }).FirstOrDefault();
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
            productSelected.product_name = product.product_name;
            productSelected.description = product.description;
            productSelected.price_ht = product.price_ht;
            productSelected.reference = product.reference;
            productSelected.bottled_year = product.bottled_year;
            productSelected.picture = product.picture;
            productSelected.origine = product.origine;
            productSelected.stock = product.stock;
            productSelected.supplier_price = product.supplier_price;
            productSelected.price_carton = product.price_carton;
            productSelected.id_supplier = product.id_supplier;
            productSelected.id_category = product.id_category;
            productSelected.id_product = product.id_family;
            _ctx.Product.Update(productSelected);
            _ctx.SaveChanges();
            return product;
        }
    }
}

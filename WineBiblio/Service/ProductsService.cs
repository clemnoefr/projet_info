using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineBiblio.Business;
using WineBiblio.Core.Data;

namespace WineBiblio.Service
{
    public class ProductsService
    {
        private readonly MyDataContext _ctx;

        public ProductsService(MyDataContext ctx)
        {
            _ctx = ctx;
        }

        public Products Add(Business.Products Products)
        {
            var Prod = new Data.DAO.Products
            {
                product_name = Products.product_name,
                description = Products.description,
                price_ht = Products.price_ht,
                reference = Products.reference,
                bottled_year = Products.bottled_year,
                picture = Products.picture,
                origine = Products.origine,
                stock = Products.stock,
                supplier_price = Products.supplier_price,
                price_carton = Products.price_carton,
                id_supplier = Products.id_supplier,
                id_category = Products.id_category,
                id_family = Products.id_family
                
            };
            _ctx.Products.Add(Prod);
            _ctx.SaveChanges();
            Products.id_product = Prod.id_product;
            return Products;
        }

        public List<Products> Get()
        {
            return (from c in _ctx.Products select new Products { id_product = c.id_product, product_name = c.product_name, description = c.description, price_ht=c.price_ht, reference = c.reference, bottled_year = c.bottled_year, picture = c.picture, origine = c.origine, stock = c.stock,supplier_price = c.supplier_price, price_carton = c.price_carton, id_supplier = c.id_supplier, id_category = c.id_category, id_family = c.id_family }).ToList();
        }

        public Products Get(int id)
        {
            return (from c in _ctx.Products where c.id_product == id select new Products { id_product = c.id_product, product_name = c.product_name, description = c.description, price_ht = c.price_ht, reference = c.reference, bottled_year = c.bottled_year, picture = c.picture, origine = c.origine, stock = c.stock, supplier_price = c.supplier_price, price_carton = c.price_carton, id_supplier = c.id_supplier, id_category = c.id_category, id_family = c.id_family }).FirstOrDefault();
        }

        public void Delete(int id)
        {
            var cat = _ctx.Products.Where(c => c.id_product == id).FirstOrDefault();
            _ctx.Products.Remove(cat);
            _ctx.SaveChanges();
        }

        public Products Edit(int id, Products products)
        {
            var productSelected = _ctx.Products.Where(c => c.id_product == id).FirstOrDefault();
            productSelected.product_name = products.product_name;
            productSelected.description = products.description;
            productSelected.price_ht = products.price_ht;
            productSelected.reference = products.reference;
            productSelected.bottled_year = products.bottled_year;
            productSelected.picture = products.picture;
            productSelected.origine = products.origine;
            productSelected.stock = products.stock;
            productSelected.supplier_price = products.supplier_price;
            productSelected.price_carton = products.price_carton;
            productSelected.id_supplier = products.id_supplier;
            productSelected.id_category = products.id_category;
            productSelected.id_product = products.id_family;
            _ctx.Products.Update(productSelected);
            _ctx.SaveChanges();
            return products;
        }
    }
}

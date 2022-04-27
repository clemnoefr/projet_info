using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineBiblio.Business;
using WineBiblio.Core.Data;


namespace WineBiblio.Service
{
    public class CategoriesService
    {
        private readonly MyDataContext _ctx;

        public CategoriesService(MyDataContext ctx)
        {
            _ctx = ctx;
        }

        public Categories Add(Categories categories)
        {
            var cat = new Data.DAO.Categories
            {
                category_name = categories.category_name
            };
            _ctx.Categories.Add(cat);
            _ctx.SaveChanges();
            categories.id_category = cat.id_category;
            return categories;
        }

        public List<Categories> Get()
        {
            return (from c in _ctx.Categories select new Categories { id_category = c.id_category, category_name = c.category_name }).ToList();
        }

        public Categories Get(int id)
        {
            return (from c in _ctx.Categories where c.id_category == id select new Categories { id_category = c.id_category, category_name = c.category_name }).FirstOrDefault();
        }

        public void Delete(int id)
        {
            var cat = _ctx.Categories.Where(c => c.id_category == id).FirstOrDefault();
            _ctx.Categories.Remove(cat);
            _ctx.SaveChanges();
        }

        public Categories Edit(int id, Categories categories)
        {
            var catSelected= _ctx.Categories.Where(c => c.id_category == id).FirstOrDefault();
            catSelected.category_name = categories.category_name;
            _ctx.Categories.Update(catSelected);
            _ctx.SaveChanges();
            return categories;
        }



    }

}

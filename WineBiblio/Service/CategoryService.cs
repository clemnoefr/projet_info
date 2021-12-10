using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineBiblio.Business;
using WineBiblio.Core.Data;

namespace WineBiblio.Service
{
    public class CategoryService
    {
        private readonly MyDataContext _ctx;

        public CategoryService(MyDataContext ctx)
        {
            _ctx = ctx;
        }

        public Category Add(Category category)
        {
            var cat = new Data.DAO.Category
            {
                name = category.name
            };
            _ctx.Category.Add(cat);
            _ctx.SaveChanges();
            category.id_category = cat.id_category;
            return category;
        }

        public List<Category> Get()
        {
            return (from c in _ctx.Category select new Category { id_category = c.id_category, name = c.name }).ToList();
        }

        public Category Get(int id)
        {
            return (from c in _ctx.Category where c.id_category == id select new Category { id_category = c.id_category, name = c.name }).FirstOrDefault();
        }

        public void Delete(int id)
        {
            var cat = _ctx.Category.Where(c => c.id_category == id).FirstOrDefault();
            _ctx.Category.Remove(cat);
            _ctx.SaveChanges();
        }

        public void Edit(Category model)
        {
            var category = _ctx.Category.Where(c => c.id_category == model.id_category).FirstOrDefault();
            category.name = model.name;
            _ctx.SaveChanges();
        }
    }
}

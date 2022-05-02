using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineBiblio.Business;
using WineBiblio.Core.Data;

namespace WineBiblio.Service
{
    public class ContainsService
    {
        private readonly MyDataContext _ctx;

        public ContainsService(MyDataContext ctx)
        {
            _ctx = ctx;
        }

        public Contains Add(Contains contains)
        {
            var cont = new Data.DAO.Contains
            {
                quantity = contains.quantity,
                id_order = contains.id_order,
                id_product = contains.id_product,
            };
            _ctx.Contains.Add(cont);
            _ctx.SaveChanges();
            contains.id_contains = cont.id_contains;
            return contains;
        }

        public List<Contains> Get()
        {
            return (from c in _ctx.Contains select new Contains { id_contains = c.id_contains, quantity = c.quantity, id_order = c.id_order, id_product = c.id_product }).ToList();
        }

        public List<Contains> Get(int id)
        {
            return (from c in _ctx.Contains where c.id_contains == id select new Contains { id_contains = c.id_contains, quantity = c.quantity, id_order = c.id_order, id_product = c.id_product }).ToList();
        }

        public Contains Edit(int id, Contains contains)
        {
            var containSelected = _ctx.Contains.Where(c => c.id_contains == id).FirstOrDefault();
            containSelected.quantity = contains.quantity;
            containSelected.id_product = contains.id_product;
            containSelected.id_order = contains.id_order;
            _ctx.Contains.Update(containSelected);
            _ctx.SaveChanges();
            return contains;
        }
    }
}

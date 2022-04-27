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

        public Contains Add(Contains contain)
        {
            var cont = new Data.DAO.Contains
            {
                quantity = contain.quantity,
                id_order = contain.id_order,
                id_product = contain.id_product,
            };
            _ctx.Contain.Add(cont);
            _ctx.SaveChanges();
            contain.id_order = cont.id_order;
            return contain;
        }

        public List<Contains> Get()
        {
            return (from c in _ctx.Contain select new Contains { quantity = c.quantity, id_order = c.id_order, id_product = c.id_product }).ToList();
        }

        public List<Contains> Get(int id)
        {
            return (from c in _ctx.Contain where c.id_order == id select new Contains { quantity = c.quantity, id_order = c.id_order, id_product = c.id_product }).ToList();
        }

        public Contains Edit(int id, Contains contain)
        {
            var containSelected = _ctx.Contain.Where(c => c.id_order == id).FirstOrDefault();
            containSelected.quantity = contain.quantity;
            containSelected.id_product = contain.id_product;
            _ctx.Contain.Update(containSelected);
            _ctx.SaveChanges();
            return contain;
        }
    }
}

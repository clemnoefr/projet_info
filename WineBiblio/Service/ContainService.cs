using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineBiblio.Business;
using WineBiblio.Core.Data;

namespace WineBiblio.Service
{
    public class ContainService
    {
        private readonly MyDataContext _ctx;

        public ContainService(MyDataContext ctx)
        {
            _ctx = ctx;
        }

        public Contain Add(Contain contain)
        {
            var cont = new Data.DAO.Contain
            {
                quantity_sell = contain.quantity_sell
            };
            _ctx.Contain.Add(cont);
            _ctx.SaveChanges();
            contain.id_contain = cont.id_contain;
            return contain;
        }

        public List<Contain> Get()
        {
            return (from c in _ctx.Contain select new Contain { id_contain = c.id_contain, quantity_sell = c.quantity_sell }).ToList();
        }

        public Contain Get(int id)
        {
            return (from c in _ctx.Contain where c.id_contain == id select new Contain { id_contain = c.id_contain, quantity_sell = c.quantity_sell }).FirstOrDefault();
        }

        public void Delete(int id)
        {
            var cat = _ctx.Contain.Where(c => c.id_contain == id).FirstOrDefault();
            _ctx.Contain.Remove(cat);
            _ctx.SaveChanges();
        }

        public Contain Edit(int id, Contain contain)
        {
            var containSelected = _ctx.Contain.Where(c => c.id_contain == id).FirstOrDefault();
            containSelected.quantity_sell = contain.quantity_sell;
            _ctx.Contain.Update(containSelected);
            _ctx.SaveChanges();
            return contain;
        }
    }
}

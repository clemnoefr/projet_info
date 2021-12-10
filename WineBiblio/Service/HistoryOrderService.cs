using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineBiblio.Business;
using WineBiblio.Core.Data;

namespace WineBiblio.Service
{
    public class HistoryOrderService
    { 
        private readonly MyDataContext _ctx;

        public HistoryOrderService(MyDataContext ctx)
        {
            _ctx = ctx;
        }

        public HistoryOrder Add(Business.HistoryOrder HistoryOrder)
        {
            var HisOrd = new Data.DAO.HistoryOrder
            {
                order_file = HistoryOrder.order_file
            };
            _ctx.HistoryOrder.Add(HisOrd);
            _ctx.SaveChanges();
            HistoryOrder.id_history_order = HisOrd.id_history_order;
            return HistoryOrder;
        }

        public List<HistoryOrder> Get()
        {
            return (from c in _ctx.HistoryOrder select new HistoryOrder { id_history_order = c.id_history_order, order_file = c.order_file }).ToList();
        }

        public HistoryOrder Get(int id)
        {
            return (from c in _ctx.HistoryOrder where c.id_history_order == id select new HistoryOrder { id_history_order = c.id_history_order, order_file = c.order_file }).FirstOrDefault();
        }

        public void Delete(int id)
        {
            var cat = _ctx.HistoryOrder.Where(c => c.id_history_order == id).FirstOrDefault();
            _ctx.HistoryOrder.Remove(cat);
            _ctx.SaveChanges();
        }

        public void Edit(HistoryOrder model)
        {
            var HistoryOrder = _ctx.HistoryOrder.Where(c => c.id_history_order == model.id_history_order).FirstOrDefault();
            HistoryOrder.order_file = model.order_file;
            _ctx.SaveChanges();
        }
    }
}

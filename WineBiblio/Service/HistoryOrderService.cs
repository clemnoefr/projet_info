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

        public HistoryOrder Add(HistoryOrder HistoryOrder)
        {
            var HisOrd = new Data.DAO.HistoryOrder
            {
                order_file = HistoryOrder.order_file,
                id_order = HistoryOrder.Order.id_order

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

        public HistoryOrder Edit(int id, HistoryOrder historyOrder)
        {
            var historyOrderSelected = _ctx.HistoryOrder.Where(c => c.id_history_order == id).FirstOrDefault();
            historyOrderSelected.order_file = historyOrder.order_file;
            _ctx.HistoryOrder.Update(historyOrderSelected);
            _ctx.SaveChanges();
            return historyOrder;
        }
    }
}

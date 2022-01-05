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

        public History_Order Add(History_Order HistoryOrder)
        {
            var HisOrd = new Data.DAO.History_Order
            {
                order_file = HistoryOrder.order_file,
                id_order = HistoryOrder.id_order

            };
            _ctx.History_Order.Add(HisOrd);
            _ctx.SaveChanges();
            HistoryOrder.id_history_order = HisOrd.id_history_order;
            return HistoryOrder;
        }

        public List<History_Order> Get()
        {
            return (from c in _ctx.History_Order select new History_Order { id_history_order = c.id_history_order, order_file = c.order_file, id_order = c.id_order }).ToList();
        }

        public History_Order Get(int id)
        {
            return (from c in _ctx.History_Order where c.id_history_order == id select new History_Order { id_history_order = c.id_history_order, order_file = c.order_file, id_order = c.id_order }).FirstOrDefault();
        }

        public void Delete(int id)
        {
            var cat = _ctx.History_Order.Where(c => c.id_history_order == id).FirstOrDefault();
            _ctx.History_Order.Remove(cat);
            _ctx.SaveChanges();
        }

        public History_Order Edit(int id, History_Order historyOrder)
        {
            var historyOrderSelected = _ctx.History_Order.Where(c => c.id_history_order == id).FirstOrDefault();
            historyOrderSelected.order_file = historyOrder.order_file;
            historyOrderSelected.id_order = historyOrder.id_order;
            _ctx.History_Order.Update(historyOrderSelected);
            _ctx.SaveChanges();
            return historyOrder;
        }
    }
}

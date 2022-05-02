using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineBiblio.Business;
using WineBiblio.Core.Data;

namespace WineBiblio.Service
{
    public class OrdersService
    {
        private readonly MyDataContext _ctx;

        public OrdersService(MyDataContext ctx)
        {
            _ctx = ctx;
        }

        public Orders Add(Orders Orders)
        {
            var order = new Data.DAO.Orders
            {
                
                status = Orders.status,
                total_ht = Orders.total_ht,
                total_ttc = Orders.total_ttc,
                TVA = Orders.TVA,
                id_customer = Orders.id_customer,

            };
            _ctx.Orders.Add(order);
            _ctx.SaveChanges();
            Orders.id_order = order.id_order;
            return Orders;
        }

        public List<Orders> Get() 
        {
            return (from c in _ctx.Orders select new Orders { id_order = c.id_order, status = c.status, total_ht = c.total_ht, total_ttc = c.total_ttc, TVA = c.TVA, id_customer = c.id_customer
            }).ToList();
        }

        public Orders Get(int id)
        {
            return (from c in _ctx.Orders where c.id_order == id select new Orders { id_order = c.id_order, status = c.status, total_ht = c.total_ht, total_ttc = c.total_ttc, TVA = c.TVA, id_customer = c.id_customer }).FirstOrDefault();
        }

        public void Delete(int id)
        {
            var cat = _ctx.Orders.Where(c => c.id_order == id).FirstOrDefault();
            _ctx.Orders.Remove(cat);
            _ctx.SaveChanges();
        }

        public Orders Edit(int id, Orders order)
        {
            var orderSelected = _ctx.Orders.Where(c => c.id_order == id).FirstOrDefault();
            orderSelected.status = order.status;
            orderSelected.total_ht = order.total_ht;
            orderSelected.total_ttc = order.total_ttc;
            orderSelected.TVA = order.TVA;
            orderSelected.id_customer = order.id_customer;
            _ctx.Orders.Update(orderSelected);
            _ctx.SaveChanges();
            return order;
        }
    }
}

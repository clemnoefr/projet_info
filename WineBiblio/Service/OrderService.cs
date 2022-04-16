using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineBiblio.Business;
using WineBiblio.Core.Data;

namespace WineBiblio.Service
{
    public class OrderService
    {
        private readonly MyDataContext _ctx;

        public OrderService(MyDataContext ctx)
        {
            _ctx = ctx;
        }

        public Order Add(Order Order)
        {
            var order = new Data.DAO.Order
            {
                status = Order.status,
                total_ht = Order.total_ht,
                total_ttc = Order.total_ttc,
                TVA = Order.TVA,
                id_invoice = Order.id_invoice,
                id_address = Order.id_address

            };
            _ctx.Order.Add(order);
            _ctx.SaveChanges();
            Order.id_order = order.id_order;
            return Order;
        }

        public List<Order> Get() 
        {
            return (from c in _ctx.Order select new Order { id_order = c.id_order, status = c.status, total_ht = c.total_ht, total_ttc = c.total_ttc, TVA = c.TVA, id_invoice = c.id_invoice, id_address = c.id_address
            }).ToList();
        }

        public Order Get(int id)
        {
            return (from c in _ctx.Order where c.id_order == id select new Order { id_order = c.id_order, status = c.status, total_ht = c.total_ht, total_ttc = c.total_ttc, TVA = c.TVA, id_invoice = c.id_invoice, id_address = c.id_address }).FirstOrDefault();
        }

        public void Delete(int id)
        {
            var cat = _ctx.Order.Where(c => c.id_order == id).FirstOrDefault();
            _ctx.Order.Remove(cat);
            _ctx.SaveChanges();
        }

        public Order Edit(int id, Order order)
        {
            var orderSelected = _ctx.Order.Where(c => c.id_order == id).FirstOrDefault();
            orderSelected.status = order.status;
            orderSelected.total_ht = order.total_ht;
            orderSelected.total_ttc = order.total_ttc;
            orderSelected.TVA = order.TVA;
            orderSelected.id_invoice = order.id_invoice;
            orderSelected.id_address = order.id_address;
            _ctx.Order.Update(orderSelected);
            _ctx.SaveChanges();
            return order;
        }
    }
}

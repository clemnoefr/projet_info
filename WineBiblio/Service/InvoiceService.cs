using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineBiblio.Business;
using WineBiblio.Core.Data;

namespace WineBiblio.Service
{
    public class InvoiceService
    {
        private readonly MyDataContext _ctx;

        public InvoiceService(MyDataContext ctx)
        {
            _ctx = ctx;
        }

        public Invoice Add(Business.Invoice invoice)
        {
            var inv = new Data.DAO.Invoice
            {
                TVA = invoice.TVA,
                price_TTC = invoice.price_TTC
            };
            _ctx.Invoice.Add(inv);
            _ctx.SaveChanges();
            invoice.id_invoice = inv.id_invoice;
            return invoice;
        }

        public List<Invoice> Get()
        {
            return (from c in _ctx.Invoice select new Invoice { id_invoice = c.id_invoice, TVA = c.TVA, price_TTC = c.price_TTC }).ToList();
        }

        public Invoice Get(int id)
        {
            return (from c in _ctx.Invoice where c.id_invoice == id select new Invoice { id_invoice = c.id_invoice, TVA = c.TVA, price_TTC = c.price_TTC }).FirstOrDefault();
        }

        public void Delete(int id)
        {
            var cat = _ctx.Invoice.Where(c => c.id_invoice == id).FirstOrDefault();
            _ctx.Invoice.Remove(cat);
            _ctx.SaveChanges();
        }

        public void Edit(Invoice model)
        {
            var invoice = _ctx.Invoice.Where(c => c.id_invoice == model.id_invoice).FirstOrDefault();
            invoice.TVA = model.TVA;
            invoice.price_TTC = model.price_TTC;

            _ctx.SaveChanges();
        }
    }
}

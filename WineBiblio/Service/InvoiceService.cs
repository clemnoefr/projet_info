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

        public Invoice Add(Invoice invoice)
        {
            var inv = new Data.DAO.Invoice
            {
                reference = invoice.reference,
                status = invoice.status,
                id_order = invoice.id_order
            };
            _ctx.Invoice.Add(inv);
            _ctx.SaveChanges();
            invoice.id_invoice = inv.id_invoice;
            return invoice;
        }

        public List<Invoice> Get()
        {
            return (from c in _ctx.Invoice select new Invoice { id_invoice = c.id_invoice, reference = c.reference, status = c.status, id_order = c.id_order }).ToList();
        }

        public Invoice Get(int id)
        {
            return (from c in _ctx.Invoice where c.id_invoice == id select new Invoice { id_invoice = c.id_invoice, reference = c.reference, status = c.status, id_order = c.id_order }).FirstOrDefault();
        }

        public void Delete(int id)
        {
            var cat = _ctx.Invoice.Where(c => c.id_invoice == id).FirstOrDefault();
            _ctx.Invoice.Remove(cat);
            _ctx.SaveChanges();
        }

        public Invoice Edit(int id, Invoice invoice)
        {
            var invoiceSelected = _ctx.Invoice.Where(c => c.id_invoice == id).FirstOrDefault();
            invoiceSelected.reference = invoice.reference;
            invoiceSelected.status = invoice.status;
            invoiceSelected.id_order = invoice.id_order;
            _ctx.Invoice.Update(invoiceSelected);
            _ctx.SaveChanges();
            return invoice;
        }
    }
}

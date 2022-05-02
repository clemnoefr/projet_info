using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineBiblio.Business;
using WineBiblio.Core.Data;

namespace WineBiblio.Service
{
    public class InvoicesService
    {
        private readonly MyDataContext _ctx;

        public InvoicesService(MyDataContext ctx)
        {
            _ctx = ctx;
        }

        public Invoices Add(Invoices invoices)
        {
            var inv = new Data.DAO.Invoices
            {
                reference = invoices.reference,
                status = invoices.status,
                id_order = invoices.id_order
            };
            _ctx.Invoices.Add(inv);
            _ctx.SaveChanges();
            invoices.id_invoice = inv.id_invoice;
            return invoices;
        }

        public List<Invoices> Get()
        {
            return (from c in _ctx.Invoices select new Invoices { id_invoice = c.id_invoice, reference = c.reference, status = c.status, id_order = c.id_order }).ToList();
        }

        public Invoices Get(int id)
        {
            return (from c in _ctx.Invoices where c.id_invoice == id select new Invoices { id_invoice = c.id_invoice, reference = c.reference, status = c.status, id_order = c.id_order }).FirstOrDefault();
        }

        public void Delete(int id)
        {
            var cat = _ctx.Invoices.Where(c => c.id_invoice == id).FirstOrDefault();
            _ctx.Invoices.Remove(cat);
            _ctx.SaveChanges();
        }

        public Invoices Edit(int id, Invoices invoices)
        {
            var invoiceSelected = _ctx.Invoices.Where(c => c.id_invoice == id).FirstOrDefault();
            invoiceSelected.reference = invoices.reference;
            invoiceSelected.status = invoices.status;
            invoiceSelected.id_order = invoices.id_order;
            _ctx.Invoices.Update(invoiceSelected);
            _ctx.SaveChanges();
            return invoices;
        }
    }
}

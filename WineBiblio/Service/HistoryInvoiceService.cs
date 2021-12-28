using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineBiblio.Business;
using WineBiblio.Core.Data;

namespace WineBiblio.Service
{
    public class HistoryInvoiceService
    {
        private readonly MyDataContext _ctx;

        public HistoryInvoiceService(MyDataContext ctx)
        {
            _ctx = ctx;
        }

        public History_Invoice Add(History_Invoice HistoryInvoice)
        {
            var HisIn = new Data.DAO.History_Invoice
            {
                file_invoice = HistoryInvoice.file_invoice,
                id_invoice = HistoryInvoice.id_invoice

            };
            _ctx.History_Invoice.Add(HisIn);
            _ctx.SaveChanges();
            HistoryInvoice.id_history_invoice = HisIn.id_history_invoice;
            return HistoryInvoice;
        }

        public List<History_Invoice> Get()
        {
            return (from c in _ctx.History_Invoice select new History_Invoice { id_history_invoice = c.id_history_invoice, file_invoice = c.file_invoice, id_invoice = c.id_invoice }).ToList();
        }

        public History_Invoice Get(int id)
        {
            return (from c in _ctx.History_Invoice where c.id_history_invoice == id select new History_Invoice { id_history_invoice = c.id_invoice, file_invoice = c.file_invoice, id_invoice = c.id_invoice }).FirstOrDefault();
        }

        public void Delete(int id)
        {
            var cat = _ctx.History_Invoice.Where(c => c.id_history_invoice == id).FirstOrDefault();
            _ctx.History_Invoice.Remove(cat);
            _ctx.SaveChanges();
        }

        public History_Invoice Edit(int id, History_Invoice historyInvoice)
        {
            var historyInvoiceSelected = _ctx.History_Invoice.Where(c => c.id_history_invoice == id).FirstOrDefault();
            historyInvoiceSelected.file_invoice = historyInvoice.file_invoice;
            historyInvoiceSelected.id_invoice = historyInvoice.id_invoice;
            _ctx.History_Invoice.Update(historyInvoiceSelected);
            _ctx.SaveChanges();
            return historyInvoice;
        }
    }
}

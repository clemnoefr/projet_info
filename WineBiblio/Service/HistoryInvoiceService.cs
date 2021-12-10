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

        public HistoryInvoice Add(Business.HistoryInvoice HistoryInvoice)
        {
            var HisIn = new Data.DAO.HistoryInvoice
            {
                file_invoice = HistoryInvoice.file_invoice,

            };
            _ctx.HistoryInvoice.Add(HisIn);
            _ctx.SaveChanges();
            HistoryInvoice.id_history_invoice = HisIn.id_history_invoice;
            return HistoryInvoice;
        }

        public List<HistoryInvoice> Get()
        {
            return (from c in _ctx.HistoryInvoice select new HistoryInvoice { id_history_invoice = c.id_history_invoice, file_invoice = c.file_invoice }).ToList();
        }

        public HistoryInvoice Get(int id)
        {
            return (from c in _ctx.HistoryInvoice where c.id_history_invoice == id select new HistoryInvoice { id_history_invoice = c.id_invoice, file_invoice = c.file_invoice }).FirstOrDefault();
        }

        public void Delete(int id)
        {
            var cat = _ctx.HistoryInvoice.Where(c => c.id_history_invoice == id).FirstOrDefault();
            _ctx.HistoryInvoice.Remove(cat);
            _ctx.SaveChanges();
        }

        public void Edit(HistoryInvoice model)
        {
            var HistoryInvoice = _ctx.HistoryInvoice.Where(c => c.id_history_invoice == model.id_history_invoice).FirstOrDefault();
            HistoryInvoice.file_invoice = model.file_invoice;
            _ctx.SaveChanges();
        }
    }
}

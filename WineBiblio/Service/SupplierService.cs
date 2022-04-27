using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineBiblio.Business;
using WineBiblio.Core.Data;

namespace WineBiblio.Service
{
    public class SupplierService
    {
        private readonly MyDataContext _ctx;

        public SupplierService(MyDataContext ctx)
        {
            _ctx = ctx;
        }

        public Supplier Add(Supplier supplier)
        {
            var supp = new Data.DAO.Supplier
            {
                name = supplier.name,
                phone = supplier.phone,
                supplier_code = supplier.supplier_code,
                id_address = supplier.id_address,
            };
            _ctx.Supplier.Add(supp);
            _ctx.SaveChanges();
            supplier.id_supplier = supp.id_supplier;
            return supplier;
        }

        public List<Supplier> Get()
        {
            return (from c in _ctx.Supplier select new Supplier { id_supplier = c.id_supplier, name = c.name, phone = c.phone, supplier_code = c.supplier_code, id_address = c.id_address
            }).ToList();
        }

        public Supplier Get(int id)
        {
            return (from c in _ctx.Supplier where c.id_supplier == id select new Supplier { id_supplier = c.id_supplier, name = c.name, phone = c.phone, supplier_code = c.supplier_code, id_address = c.id_address }).FirstOrDefault();
        }

        public void Delete(int id)
        {
            var cat = _ctx.Supplier.Where(c => c.id_supplier == id).FirstOrDefault();
            _ctx.Supplier.Remove(cat);
            _ctx.SaveChanges();
        }

        public Supplier Edit(int id, Supplier supplier)
        {
            var supplierSelected = _ctx.Supplier.Where(c => c.id_supplier == id).FirstOrDefault();
            supplierSelected.name = supplier.name;
            supplierSelected.phone = supplier.phone;
            supplierSelected.supplier_code = supplier.supplier_code;
            supplierSelected.id_address = supplier.id_address;
            _ctx.Supplier.Update(supplierSelected);
            _ctx.SaveChanges();
            return supplier;
        }
    }
}

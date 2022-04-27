using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineBiblio.Business;
using WineBiblio.Core.Data;

namespace WineBiblio.Service
{
    public class SuppliersService
    {
        private readonly MyDataContext _ctx;

        public SuppliersService(MyDataContext ctx)
        {
            _ctx = ctx;
        }

        public Suppliers Add(Suppliers suppliers)
        {
            var supp = new Data.DAO.Suppliers
            {
                name = suppliers.name,
                phone = suppliers.phone,
                supplier_code = suppliers.supplier_code,
                id_address = suppliers.id_address,
            };
            _ctx.Suppliers.Add(supp);
            _ctx.SaveChanges();
            suppliers.id_supplier = supp.id_supplier;
            return suppliers;
        }

        public List<Suppliers> Get()
        {
            return (from c in _ctx.Suppliers select new Suppliers { id_supplier = c.id_supplier, name = c.name, phone = c.phone, supplier_code = c.supplier_code, id_address = c.id_address
            }).ToList();
        }

        public Suppliers Get(int id)
        {
            return (from c in _ctx.Suppliers where c.id_supplier == id select new Suppliers { id_supplier = c.id_supplier, name = c.name, phone = c.phone, supplier_code = c.supplier_code, id_address = c.id_address }).FirstOrDefault();
        }

        public void Delete(int id)
        {
            var cat = _ctx.Suppliers.Where(c => c.id_supplier == id).FirstOrDefault();
            _ctx.Suppliers.Remove(cat);
            _ctx.SaveChanges();
        }

        public Suppliers Edit(int id, Suppliers suppliers)
        {
            var supplierSelected = _ctx.Suppliers.Where(c => c.id_supplier == id).FirstOrDefault();
            supplierSelected.name = suppliers.name;
            supplierSelected.phone = suppliers.phone;
            supplierSelected.supplier_code = suppliers.supplier_code;
            supplierSelected.id_address = suppliers.id_address;
            _ctx.Suppliers.Update(supplierSelected);
            _ctx.SaveChanges();
            return suppliers;
        }
    }
}

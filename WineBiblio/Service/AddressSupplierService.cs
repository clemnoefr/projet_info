using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineBiblio.Business;
using WineBiblio.Core.Data;

namespace WineBiblio.Service
{
    public class AddressSupplierService
    {
        private readonly MyDataContext _ctx;

        public AddressSupplierService(MyDataContext ctx)
        {
            _ctx = ctx;
        }

        public Address_Supplier Add(Business.Address_Supplier AddressSupplier)
        {
            var AddSup = new Data.DAO.Address_Supplier
            {
                address_type = AddressSupplier.address_type,
                address = AddressSupplier.address,
                id_supplier = AddressSupplier.id_supplier
               
            };
            _ctx.Address_Supplier.Add(AddSup);
            _ctx.SaveChanges();
            AddressSupplier.id_address_supplier = AddSup.id_address_supplier;
            return AddressSupplier;
        }

        public List<Address_Supplier> Get()
        {
            return (from c in _ctx.Address_Supplier select new Address_Supplier { id_address_supplier = c.id_address_supplier, address_type = c.address_type, address = c.address, id_supplier = c.id_supplier }).ToList();
        }

        public Address_Supplier Get(int id)
        {
            return (from c in _ctx.Address_Supplier where c.id_address_supplier == id select new Address_Supplier { id_address_supplier = c.id_address_supplier, address_type = c.address_type, address = c.address, id_supplier = c.id_supplier }).FirstOrDefault();
        }

        public void Delete(int id)
        {
            var cat = _ctx.Address_Supplier.Where(c => c.id_address_supplier == id).FirstOrDefault();
            _ctx.Address_Supplier.Remove(cat);
            _ctx.SaveChanges();
        }

        public Address_Supplier Edit(int id, Address_Supplier addressSupplier)
        {
            var addressSelected = _ctx.Address_Supplier.Where(c => c.id_address_supplier == id).FirstOrDefault();
            addressSelected.address_type = addressSupplier.address_type;
            addressSelected.address = addressSupplier.address;
            addressSelected.id_supplier = addressSelected.id_supplier;
            _ctx.Address_Supplier.Update(addressSelected);
            _ctx.SaveChanges();
            return addressSupplier;
        }
    }
}

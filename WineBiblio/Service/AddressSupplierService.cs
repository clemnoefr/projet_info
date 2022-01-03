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

        public AddressSupplier Add(Business.AddressSupplier AddressSupplier)
        {
            var AddSup = new Data.DAO.AddressSupplier
            {
                address_type = AddressSupplier.address_type,
                address = AddressSupplier.address,
                id_supplier = AddressSupplier.id_supplier
               
            };
            _ctx.AddressSupplier.Add(AddSup);
            _ctx.SaveChanges();
            AddressSupplier.id_address_supplier = AddSup.id_address_supplier;
            return AddressSupplier;
        }

        public List<AddressSupplier> Get()
        {
            return (from c in _ctx.AddressSupplier select new AddressSupplier { id_address_supplier = c.id_address_supplier, address_type = c.address_type, address = c.address }).ToList();
        }

        public AddressSupplier Get(int id)
        {
            return (from c in _ctx.AddressSupplier where c.id_address_supplier == id select new AddressSupplier { id_address_supplier = c.id_address_supplier, address_type = c.address_type, address = c.address }).FirstOrDefault();
        }

        public void Delete(int id)
        {
            var cat = _ctx.AddressSupplier.Where(c => c.id_address_supplier == id).FirstOrDefault();
            _ctx.AddressSupplier.Remove(cat);
            _ctx.SaveChanges();
        }

        public AddressSupplier Edit(int id, AddressSupplier addressSupplier)
        {
            var addressSelected = _ctx.AddressSupplier.Where(c => c.id_address_supplier == id).FirstOrDefault();
            addressSelected.address_type = addressSupplier.address_type;
            addressSelected.address = addressSupplier.address;
            _ctx.AddressSupplier.Update(addressSelected);
            _ctx.SaveChanges();
            return addressSupplier;
        }
    }
}

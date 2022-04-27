using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineBiblio.Business;
using WineBiblio.Core.Data;

namespace WineBiblio.Service
{
    public class AddressesService
    {
        private readonly MyDataContext _ctx;

        public AddressesService(MyDataContext ctx)
        {
            _ctx = ctx;
        }


        public List<Addresses> Get()
        {
            return (from c in _ctx.Addresses select new Addresses { id_address = c.id_address, id_type = c.id_type,address = c.address, id_customer = c.id_customer, id_supplier = c.id_supplier }).ToList();
        }

        public Addresses Get(int id)
        {
            return (from c in _ctx.Addresses where c.id_address == id select new Addresses { id_address = c.id_address, id_type = c.id_type, address = c.address, id_customer = c.id_customer, id_supplier = c.id_supplier }).FirstOrDefault();
        }

        public Addresses Add(Addresses address)
        {
            var addr = new Data.DAO.Addresses
            {
               address = address.address,
               id_customer = address.id_customer,
               id_type = address.id_type,
               id_supplier = address.id_supplier,

            };
            _ctx.Addresses.Add(addr);
            _ctx.SaveChanges();
            address.id_address = addr.id_address;
            return address;
        }


        public void Delete(int id)
        {
            var cat = _ctx.Addresses.Where(c => c.id_address == id).FirstOrDefault();
            _ctx.Addresses.Remove(cat);
            _ctx.SaveChanges();
        }

        public Addresses Edit(int id, Addresses address)
        {
            var addressSelected = _ctx.Addresses.Where(a => a.id_address == id).FirstOrDefault();
            addressSelected.id_customer = address.id_customer;
            addressSelected.id_type = address.id_type;
            addressSelected.address = address.address;
            addressSelected.id_supplier = address.id_supplier;
            _ctx.Addresses.Update(addressSelected);
            _ctx.SaveChanges();
            return address;
        }
    }
}

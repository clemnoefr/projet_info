using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineBiblio.Business;
using WineBiblio.Core.Data;

namespace WineBiblio.Service
{
    public class AddressService
    {
        private readonly MyDataContext _ctx;

        public AddressService(MyDataContext ctx)
        {
            _ctx = ctx;
        }


        public List<Address> Get()
        {
            return (from c in _ctx.Address select new Address { id_address = c.id_address, id_type = c.id_type,address = c.address, id_customer = c.id_customer, id_supplier = c.id_supplier }).ToList();
        }

        public Address Get(int id)
        {
            return (from c in _ctx.Address where c.id_address == id select new Address { id_address = c.id_address, id_type = c.id_type, address = c.address, id_customer = c.id_customer, id_supplier = c.id_supplier }).FirstOrDefault();
        }

        public Address Add(Address address)
        {
            var addr = new Data.DAO.Address
            {
               address = address.address,
               id_customer = address.id_customer,
               id_type = address.id_type,
               id_supplier = address.id_supplier,

            };
            _ctx.Address.Add(addr);
            _ctx.SaveChanges();
            address.id_address = addr.id_address;
            return address;
        }


        public void Delete(int id)
        {
            var cat = _ctx.Address.Where(c => c.id_address == id).FirstOrDefault();
            _ctx.Address.Remove(cat);
            _ctx.SaveChanges();
        }

        public Address Edit(int id, Address address)
        {
            var addressSelected = _ctx.Address.Where(a => a.id_address == id).FirstOrDefault();
            addressSelected.id_customer = address.id_customer;
            addressSelected.id_type = address.id_type;
            addressSelected.address = address.address;
            addressSelected.id_supplier = address.id_supplier;
            _ctx.Address.Update(addressSelected);
            _ctx.SaveChanges();
            return address;
        }
    }
}

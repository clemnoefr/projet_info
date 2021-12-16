﻿using System;
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
            return (from c in _ctx.Address select new Address { id_address = c.id_address, address_type = c.address_type, address = c.address }).ToList();
        }

        public Address Get(int id)
        {
            return (from c in _ctx.Address where c.id_address == id select new Address { id_address = c.id_address, address_type = c.address_type, address = c.address }).FirstOrDefault();
        }

        public Address Add(Address address)
        {
            var addr = new Data.DAO.Address
            {
                address_type = address.address_type,
                address = address.address

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

        public void Edit(Address model)
        {
            var Address = _ctx.Address.Where(c => c.id_address == model.id_address).FirstOrDefault();
            Address.address_type = model.address_type;
            Address.address = model.address;
            _ctx.SaveChanges();
        }
    }
}

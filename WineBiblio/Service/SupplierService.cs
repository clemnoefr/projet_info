﻿using System;
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
                Name = supplier.Name
            };
            _ctx.Supplier.Add(supp);
            _ctx.SaveChanges();
            supplier.Name = supp.Name;
            return supplier;
        }

        public List<Supplier> Get()
        {
            return (from c in _ctx.Supplier select new Supplier { id_supplier = c.id_supplier, Name = c.Name }).ToList();
        }

        public Supplier Get(int id)
        {
            return (from c in _ctx.Supplier where c.id_supplier == id select new Supplier { id_supplier = c.id_supplier, Name = c.Name }).FirstOrDefault();
        }

        public void Delete(int id)
        {
            var cat = _ctx.Supplier.Where(c => c.id_supplier == id).FirstOrDefault();
            _ctx.Supplier.Remove(cat);
            _ctx.SaveChanges();
        }

        public void Edit(Supplier model)
        {
            var Supplier = _ctx.Supplier.Where(c => c.id_supplier == model.id_supplier).FirstOrDefault();
            Supplier.Name = model.Name;
            _ctx.SaveChanges();
        }
    }
}
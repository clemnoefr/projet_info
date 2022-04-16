using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineBiblio.Business;
using WineBiblio.Core.Data;
using Type = WineBiblio.Business.Type;

namespace WineBiblio.Service
{
    public class TypeService
    {
        private readonly MyDataContext _ctx;

        public TypeService(MyDataContext ctx)
        {
            _ctx = ctx;
        }


        public List<Type> Get()
        {
            return (from c in _ctx.Type select new Type { id_type = c.id_type, type_name = c.type_name}).ToList();
        }

        public Type Get(int id)
        {
            return (from c in _ctx.Type where c.id_type == id select new Type { id_type = c.id_type, type_name = c.type_name }).FirstOrDefault();
        }

        public Type Add(Type typ)
        {
            var type = new Data.DAO.Type
            {
                type_name = typ.type_name

            };
            _ctx.Type.Add(type);
            _ctx.SaveChanges();
            typ.id_type = type.id_type;
            return typ;
        }


        public void Delete(int id)
        {
            var cat = _ctx.Type.Where(c => c.id_type == id).FirstOrDefault();
            _ctx.Type.Remove(cat);
            _ctx.SaveChanges();
        }

        public Type Edit(int id, Type type)
        {
            var typeSelected = _ctx.Type.Where(a => a.id_type == id).FirstOrDefault();
            typeSelected.type_name = type.type_name;
            _ctx.Type.Update(typeSelected);
            _ctx.SaveChanges();
            return type;
        }
    }
}

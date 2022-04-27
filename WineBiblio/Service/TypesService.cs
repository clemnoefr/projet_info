using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineBiblio.Business;
using WineBiblio.Core.Data;
using Types = WineBiblio.Business.Types;

namespace WineBiblio.Service
{
    public class TypesService
    {
        private readonly MyDataContext _ctx;

        public TypesService(MyDataContext ctx)
        {
            _ctx = ctx;
        }


        public List<Types> Get()
        {
            return (from c in _ctx.Types select new Types { id_type = c.id_type, type_name = c.type_name}).ToList();
        }

        public Types Get(int id)
        {
            return (from c in _ctx.Types where c.id_type == id select new Types { id_type = c.id_type, type_name = c.type_name }).FirstOrDefault();
        }

        public Types Add(Types typ)
        {
            var types = new Data.DAO.Types
            {
                type_name = typ.type_name

            };
            _ctx.Types.Add(types);
            _ctx.SaveChanges();
            typ.id_type = types.id_type;
            return typ;
        }


        public void Delete(int id)
        {
            var cat = _ctx.Types.Where(c => c.id_type == id).FirstOrDefault();
            _ctx.Types.Remove(cat);
            _ctx.SaveChanges();
        }

        public Types Edit(int id, Types types)
        {
            var typeSelected = _ctx.Types.Where(a => a.id_type == id).FirstOrDefault();
            typeSelected.type_name = types.type_name;
            _ctx.Types.Update(typeSelected);
            _ctx.SaveChanges();
            return types;
        }
    }
}

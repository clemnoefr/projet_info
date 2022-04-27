using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineBiblio.Business;
using WineBiblio.Core.Data;

namespace WineBiblio.Service
{
    public class FamiliesService
    {
        private readonly MyDataContext _ctx;

        public FamiliesService(MyDataContext ctx)
        {
            _ctx = ctx;
        }


        public List<Families> Get()
        {
            return (from c in _ctx.Families select new Families { id_family = c.id_family, family_name = c.family_name }).ToList();
        }

        public Families Get(int id)
        {
            return (from c in _ctx.Families where c.id_family == id select new Families { id_family = c.id_family, family_name = c.family_name }).FirstOrDefault();
        }

        public Families Add(Families families)
        {
            var fam = new Data.DAO.Families
            {
               family_name = families.family_name

            };
            _ctx.Families.Add(fam);
            _ctx.SaveChanges();
            families.id_family = fam.id_family;
            return families;
        }


        public void Delete(int id)
        {
            var cat = _ctx.Families.Where(c => c.id_family == id).FirstOrDefault();
            _ctx.Families.Remove(cat);
            _ctx.SaveChanges();
        }

        public Families Edit(int id, Families families)
        {
            var familySelected = _ctx.Families.Where(a => a.id_family == id).FirstOrDefault();
            familySelected.family_name = families.family_name;
            _ctx.Families.Update(familySelected);
            _ctx.SaveChanges();
            return families;
        }
    }
}

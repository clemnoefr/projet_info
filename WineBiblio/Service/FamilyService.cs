using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineBiblio.Business;
using WineBiblio.Core.Data;

namespace WineBiblio.Service
{
    public class FamilyService
    {
        private readonly MyDataContext _ctx;

        public FamilyService(MyDataContext ctx)
        {
            _ctx = ctx;
        }


        public List<Family> Get()
        {
            return (from c in _ctx.Family select new Family { id_family = c.id_family, family_name = c.family_name }).ToList();
        }

        public Family Get(int id)
        {
            return (from c in _ctx.Family where c.id_family == id select new Family { id_family = c.id_family, family_name = c.family_name }).FirstOrDefault();
        }

        public Family Add(Family family)
        {
            var fam = new Data.DAO.Family
            {
               family_name = family.family_name

            };
            _ctx.Family.Add(fam);
            _ctx.SaveChanges();
            family.id_family = fam.id_family;
            return family;
        }


        public void Delete(int id)
        {
            var cat = _ctx.Family.Where(c => c.id_family == id).FirstOrDefault();
            _ctx.Family.Remove(cat);
            _ctx.SaveChanges();
        }

        public Family Edit(int id, Family family)
        {
            var familySelected = _ctx.Family.Where(a => a.id_family == id).FirstOrDefault();
            familySelected.family_name = family.family_name;
            _ctx.Family.Update(familySelected);
            _ctx.SaveChanges();
            return family;
        }
    }
}

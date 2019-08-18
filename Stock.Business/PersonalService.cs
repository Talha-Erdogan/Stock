
using Stock.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Business
{
    public class PersonalService
    {
        public List<Personal> GetAll()
        {
            using (AppDbContext db = new AppDbContext())
            {
                return db.Personal.ToList();
            }
        }

        public Personal GetPersonalById(int personalId)
        {
            using (AppDbContext db = new AppDbContext())
            {
                return db.Personal.Where(p => p.Id == personalId).FirstOrDefault();
            }
        }

        public int Add(Personal personal)
        {
            try
            {
                using (AppDbContext db = new AppDbContext())
                {
                    db.Entry(personal).State = System.Data.Entity.EntityState.Added;
                    return db.SaveChanges();
                }
            }
            catch
            {

                return 0;
            }
        }

        public int Update(Personal personal)
        {
            try
            {
                using (AppDbContext db = new AppDbContext())
                {
                    db.Entry(personal).State = System.Data.Entity.EntityState.Modified;
                    return db.SaveChanges();
                }
            }
            catch
            {
                return 0;
            }
        }

        public int Delete(int Id)
        {
            try
            {
                using (AppDbContext db = new AppDbContext())
                {
                    var personal = db.Personal.Where(x => x.Id == Id).FirstOrDefault();
                    if (personal != null)
                    {
                        db.Personal.Remove(personal);
                        return db.SaveChanges();
                    }
                    return 0;
                }
            }
            catch
            {

                return 0;
            }
        }
    }
}

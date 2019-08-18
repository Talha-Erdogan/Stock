using Stock.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Business
{
    public class BrandService
    {
        public List<Brand> GetAll()
        {
            using (AppDbContext db = new AppDbContext())
            {
                return db.Brand.ToList();
            }
        }

        public Brand GetBrandById(int brandId)
        {
            using (AppDbContext db = new AppDbContext())
            {
                return db.Brand.Where(p => p.Id == brandId).FirstOrDefault();
            }
        }

        public int Add(Brand brand)
        {
            try
            {
                using (AppDbContext db = new AppDbContext())
                {
                    db.Entry(brand).State = System.Data.Entity.EntityState.Added;
                    return db.SaveChanges();
                }
            }
            catch
            {

                return 0;
            }
        }

        public int Update(Brand brand)
        {
            try
            {
                using (AppDbContext db = new AppDbContext())
                {
                    db.Entry(brand).State = System.Data.Entity.EntityState.Modified;
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
                    var brand = db.Brand.Where(x => x.Id == Id).FirstOrDefault();
                    if (brand != null)
                    {
                        db.Brand.Remove(brand);
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

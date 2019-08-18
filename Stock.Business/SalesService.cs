using Stock.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Business
{
   public class SalesService
    {
        public List<Sales> GetAll()
        {
            using (AppDbContext db = new AppDbContext())
            {
                return db.Sales.ToList();
            }
        }

        public Sales GetSalesById(int salesId)
        {
            using (AppDbContext db = new AppDbContext())
            {
                return db.Sales.Where(p => p.Id == salesId).FirstOrDefault();
            }
        }

        public int Add(Sales sales)
        {
            try
            {
                using (AppDbContext db = new AppDbContext())
                {
                    db.Entry(sales).State = System.Data.Entity.EntityState.Added;
                    return db.SaveChanges();
                }
            }
            catch
            {

                return 0;
            }
        }

        public int Update(Sales sales)
        {
            try
            {
                using (AppDbContext db = new AppDbContext())
                {
                    db.Entry(sales).State = System.Data.Entity.EntityState.Modified;
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
                    var sales = db.Sales.Where(x => x.Id == Id).FirstOrDefault();
                    if (sales != null)
                    {
                        db.Sales.Remove(sales);
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

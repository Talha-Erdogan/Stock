using Stock.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Business
{
    public class ProductService
    {

        public List<Product> GetAll()
        {
            using (AppDbContext db = new AppDbContext())
            {
                return db.Product.ToList();
            }
        }

        public Product GetProductById(int productId)
        {
            using (AppDbContext db = new AppDbContext())
            {
                return db.Product.Where(p => p.Id == productId).FirstOrDefault();
            }
        }

        public int Add(Product product)
        {
            try
            {
                using (AppDbContext db = new AppDbContext())
                {
                    db.Entry(product).State = System.Data.Entity.EntityState.Added;
                    return db.SaveChanges();
                }
            }
            catch
            {

                return 0;
            }
        }

        public int Update(Product product)
        {
            try
            {
                using (AppDbContext db = new AppDbContext())
                {
                    db.Entry(product).State = System.Data.Entity.EntityState.Modified;
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
                    var product = db.Product.Where(x => x.Id == Id).FirstOrDefault();
                    if (product != null)
                    {
                        db.Product.Remove(product);
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

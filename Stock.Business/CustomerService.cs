using Stock.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Business
{
    public class CustomerService
    {
        public List<Customer> GetAll()
        {
            using (AppDbContext db = new AppDbContext())
            {
                return db.Customer.ToList();
            }
        }

        public Customer GetCustomerById(int customerId)
        {
            using (AppDbContext db = new AppDbContext())
            {
                return db.Customer.Where(p => p.Id == customerId).FirstOrDefault();
            }
        }

        public int Add(Customer customer)
        {
            try
            {
                using (AppDbContext db = new AppDbContext())
                {
                    db.Entry(customer).State = System.Data.Entity.EntityState.Added;
                    return db.SaveChanges();
                }
            }
            catch
            {

                return 0;
            }
        }

        public int Update(Customer customer)
        {
            try
            {
                using (AppDbContext db = new AppDbContext())
                {
                    db.Entry(customer).State = System.Data.Entity.EntityState.Modified;
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
                    var customer = db.Customer.Where(x => x.Id == Id).FirstOrDefault();
                    if (customer != null)
                    {
                        db.Customer.Remove(customer);
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

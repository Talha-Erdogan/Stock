
using Stock.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Business
{
    public class AuthorityService
    {
        private List<Authority> AuthorityList = new List<Authority>()
        {
            new Authority(){ Id=1,Name="Admin"},
            new Authority(){ Id=2,Name="Personal"},
        };
        public List<Authority> GetAll()
        {
            //using (AppDbContext db = new AppDbContext())
            //{
            //    return db.Authority.ToList();
            //}
            return AuthorityList.ToList();
        }

        public Authority GetAuthorityById(int authorityId)
        {
            //using (AppDbContext db = new AppDbContext())
            //{
            //    return db.Authority.Where(p => p.Id == authorityId).FirstOrDefault();
            //}
            return AuthorityList.Where(p => p.Id == authorityId).FirstOrDefault();
        }

        //public int Add(Authority authority)
        //{
        //    try
        //    {
        //        using (AppDbContext db = new AppDbContext())
        //        {
        //            db.Entry(authority).State = System.Data.Entity.EntityState.Added;
        //            return db.SaveChanges();
        //        }
        //    }
        //    catch
        //    {

        //        return 0;
        //    }
        //}

        //public int Update(Authority authority)
        //{
        //    try
        //    {
        //        using (AppDbContext db = new AppDbContext())
        //        {
        //            db.Entry(authority).State = System.Data.Entity.EntityState.Modified;
        //            return db.SaveChanges();
        //        }
        //    }
        //    catch
        //    {
        //        return 0;
        //    }
        //}

        //public int Delete(int Id)
        //{
        //    try
        //    {
        //        using (AppDbContext db = new AppDbContext())
        //        {
        //            var authority = db.Authority.Where(x => x.Id == Id).FirstOrDefault();
        //            if (authority != null)
        //            {
        //                db.Authority.Remove(authority);
        //                return db.SaveChanges();
        //            }
        //            return 0;
        //        }
        //    }
        //    catch
        //    {

        //        return 0;
        //    }
        //}

    }
}

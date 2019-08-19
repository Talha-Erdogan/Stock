using Stock.Business.Model;
using Stock.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Business
{
    public class UserService
    {
        public List<User> GetAll()
        {
            using (AppDbContext db = new AppDbContext())
            {
                return db.User.ToList();
            }
        }

        public UserInformation GetUserInformationByUserNameAndPassword(string userName, string password)
        {
            AuthorityService authorityService = new AuthorityService();
            using (AppDbContext db = new AppDbContext())
            {
                //return db.User.Where(p => p.UserName== userName &&p.Password==password).FirstOrDefault();
                var list = (from u in db.User
                            join p in db.Personal on u.PersonalId equals p.Id
                            //join a in authorityService.GetAll() on u.AuthorityId equals a.Id
                            where u.UserName == userName && u.Password == password
                            select new UserInformation()
                            {
                                Id = u.Id,
                                UserName = u.UserName,
                                Password = u.Password,
                                AuthorityId = u.AuthorityId,
                                //AuthorityName = a.Name,
                                PersonalId = u.PersonalId,
                                Name = p.Name,
                                Surname = p.Surname,
                                Phone = p.Phone,
                                Address = p.Address,
                                Salary = p.Salary,
                                Image = p.Image,
                                EntryDate = p.EntryDate,
                            }).FirstOrDefault();
                list.AuthorityName = authorityService.GetAuthorityById(list.AuthorityId).Name;
                return list;
            }
        }

        public User GetUserById(int userId)
        {
            using (AppDbContext db = new AppDbContext())
            {
                return db.User.Where(p => p.Id == userId).FirstOrDefault();
            }
        }

        public int Add(User user)
        {
            try
            {
                using (AppDbContext db = new AppDbContext())
                {
                    db.Entry(user).State = System.Data.Entity.EntityState.Added;
                    return db.SaveChanges();
                }
            }
            catch
            {

                return 0;
            }
        }

        public int Update(User user)
        {
            try
            {
                using (AppDbContext db = new AppDbContext())
                {
                    db.Entry(user).State = System.Data.Entity.EntityState.Modified;
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
                    var user = db.User.Where(x => x.Id == Id).FirstOrDefault();
                    if (user != null)
                    {
                        db.User.Remove(user);
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

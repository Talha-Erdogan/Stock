using Stock.Business;
using Stock.Data;
using Stock.UI.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stock.UI.Controllers
{
    [AppAuthorize]
    public class AdminController : Controller
    {

        #region Private Member
        private readonly UserService userService;
        private readonly PersonalService personalService;
        private readonly AuthorityService authorityService;
        #endregion

        #region Constructor
        public AdminController()
        {
            userService = new UserService();
            personalService = new PersonalService();
            authorityService = new AuthorityService();
        }
        #endregion

        #region List
        
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult List()
        {
            return this.Json(
            new
            {
                Result = (from per in personalService.GetAll()
                          join u in userService.GetAll() on per.Id equals u.PersonalId
                          join a in authorityService.GetAll() on u.AuthorityId equals a.Id
                          select new
                          {
                              Id = u.Id,
                              Image = per.Image,
                              Name = per.Name,
                              Surname = per.Surname,
                              UserName = u.UserName,
                              Authority = a.Name,
                          })
            }, JsonRequestBehavior.AllowGet
            );
        }
        #endregion

        #region Add
        public ActionResult UserAdd()
        {
            var personelList = personalService.GetAll();
            return View(personelList);
        }

        [HttpPost]
        public JsonResult UserAdd(User model, string repeatPassword )
        {
            if (model.PersonalId==0|| model.UserName==null)
            {
                return Json("2");
            }
            try
            {
                var user = userService.GetAll();
                if (model.Password != repeatPassword) return Json("DifferentPassword");
                foreach (var k in user)
                {
                    if (k.PersonalId == model.PersonalId)
                    {
                        return Json("CurrentRecord");
                    }
                }
                model.Password = CryptoHelper.Conversion(model.Password);
                model.AuthorityId = 2;//personal
                userService.Add(model);
                return Json("1");
            }
            catch { return Json("0"); }
        }
        #endregion

        #region Delete
        [HttpPost]
        public JsonResult Delete(int[] data)
        {
            try
            {
                if (data == null) return Json("2");
                foreach (var userId in data)
                {
                    var user = userService.GetUserById(userId);
                    if (user!=null)
                    {
                        userService.Delete(userId);
                    }
                    else
                    {
                        return Json("0");
                    }
                }
                return Json("1");
            }
            catch { return Json("0"); }
        }
        #endregion

    }
}
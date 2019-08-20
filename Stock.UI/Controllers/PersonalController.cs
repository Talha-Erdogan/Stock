using Stock.Business;
using Stock.Data;
using Stock.UI.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stock.UI.Controllers
{
    [AppAuthorize]
    public class PersonalController : Controller
    {
        #region Private Member
        PersonalService personalService;
        UserService userService;
        #endregion

        #region Constructor
        public PersonalController()
        {
            personalService = new PersonalService();
            userService = new UserService();
        }
        #endregion

        #region List
        // GET: Personal
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult List()
        {
            return this.Json(
            new
            {
                Result = (from obj in personalService.GetAll()
                          select new
                          {
                              Id = obj.Id,
                              Image = obj.Image,
                              Name = obj.Name,
                              Surname = obj.Surname,
                              Phone = obj.Phone,
                              Address = obj.Address,
                              Salary = obj.Salary,
                              EntryDate = obj.EntryDate.ToShortDateString()
                          })
            }, JsonRequestBehavior.AllowGet
            ); ;
        }
        #endregion

        #region Add
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ImageAdd()
        {
            var image = System.Web.HttpContext.Current.Request.Files["prsnlImage"];
            if (image == null)
                return Json("0");
            else if (System.IO.File.Exists(Server.MapPath("~/Content/Images/") + image.FileName))
                return Json("2");
            Session["image"] = image;
            return Json("1");
        }

        [HttpPost]
        public JsonResult Add(Personal model)
        {
            try
            {
                model.EntryDate = DateTime.Now;
                HttpPostedFile image = (HttpPostedFile)Session["image"];
                if (image == null)
                {
                    model.Image = "/Content/Images/default.png";
                    personalService.Add(model);
                }
                else
                {
                    var path = Path.Combine(Server.MapPath("~/Content/Images/") + image.FileName);
                    image.SaveAs(path);
                    model.Image = "/Content/Images/" + image.FileName;
                    personalService.Add(model);
                }
                Session.Remove("image");
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
                foreach (var personalId in data)
                {
                    var prsnl = personalService.GetPersonalById(personalId);
                    if (System.IO.File.Exists(Server.MapPath(prsnl.Image)))
                    {
                        if (prsnl.Image != "/Content/Images/default.png")
                            System.IO.File.Delete(Server.MapPath(prsnl.Image));
                    }
                    var user = userService.GetUserByPersonalId(personalId);
                    if (user!=null)
                    {
                        userService.Delete(user.Id);
                    }
                    personalService.Delete(personalId);
                }
                return Json("1");
            }
            catch { return Json("0"); }
        }
        #endregion

        #region Edit
        public ActionResult Edit(int id)
        {
            var prsnl = personalService.GetPersonalById(id);
            return View(prsnl);
        }

        [HttpPost]
        public JsonResult Edit(Personal model)
        {
            try
            {
                var personal = personalService.GetPersonalById(model.Id);
                if (personal!=null)
                {
                    HttpPostedFile image = (HttpPostedFile)Session["image"];
                    if (image == null && personal.Image != "/Content/Images/default.png")
                        personal.Image = personal.Image;
                    else if (image == null)
                        personal.Image = "/Content/Images/default.png";
                    else
                    {
                        var path = Path.Combine(Server.MapPath("~/Content/Images/") + image.FileName);
                        image.SaveAs(path);
                        personal.Image = "/Content/Images/" + image.FileName;
                    }
                    personal.Name = model.Name;
                    personal.Surname = model.Surname;
                    personal.Phone = model.Phone;
                    personal.Address = model.Address;
                    personal.Salary = model.Salary;

                    personalService.Update(personal);
                    Session.Remove("image");
                    return Json("1");
                }
                else
                {
                    return Json("0");
                }
               
            }
            catch { return Json("0"); }
        }
        #endregion
    }
}
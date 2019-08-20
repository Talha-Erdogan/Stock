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
        #endregion

        #region Constructor
        public PersonalController()
        {
            personalService = new PersonalService();
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
    }
}
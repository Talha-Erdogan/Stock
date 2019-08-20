using Stock.Business;
using Stock.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stock.UI.Controllers
{
    public class BrandController : Controller
    {
        #region Private Member
        private readonly BrandService brandService;
        #endregion

        #region Constructor
        public BrandController()
        {
            brandService = new BrandService();
        }
        #endregion
        // GET: Brand
        #region List
        public ActionResult List()
        {
            return View();
        }

        public JsonResult BrandList()
        {
            return this.Json(
            new
            {
                Result = (from obj in brandService.GetAll()
                          select new
                          {
                              Id = obj.Id,
                              Name = obj.Name,
                          })
            }, JsonRequestBehavior.AllowGet
            );
        }
        #endregion

        #region Add
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Add(Brand model)
        {
            try
            {
                if (model.Name != "" || model.Name!=null)
                {
                    brandService.Add(model);
                    return Json("1");
                }
                return Json("2");
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
                foreach (var brandId in data)
                {
                    brandService.Delete(brandId);
                }
                return Json("1");
            }
            catch { return Json("0"); }
        }
        #endregion

        #region Edit
        public ActionResult Edit(int id)
        {
            var brand = brandService.GetBrandById(id);
            return View(brand);
        }

        [HttpPost]
        public JsonResult Edit(Brand model)
        {
            try
            {
                brandService.Update(model);
                return Json("1");
            }
            catch { return Json("0"); }
        }
        #endregion
    }
}
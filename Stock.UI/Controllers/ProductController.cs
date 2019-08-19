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
    public class ProductController : Controller
    {
        #region Private Member
        private readonly ProductService productService;
        private readonly BrandService brandService;
        #endregion

        #region Constructor
        public ProductController()
        {
            productService = new ProductService();
            brandService = new BrandService();
        }
        #endregion

        #region StockInProduct,List
        public ActionResult StockInProduct()
        {
            return View();
        }

        public JsonResult List()
        {
            return this.Json(
            new
            {
                Result = (from obj in productService.GetAllWithBrandName()
                          select new
                          {
                              Id = obj.Id,
                              BrandName = obj.BrandName,
                              Name = obj.Name,
                              Piece = obj.Piece,
                              BuyingPrice = obj.BuyingPrice,
                              Kdv = obj.Kdv,
                              SalesPrice = obj.SalesPrice,
                          })
            }, JsonRequestBehavior.AllowGet
            );
        }
        #endregion

        #region Add
        public ActionResult Add()
        {
            var brand = brandService.GetAll();
            return View(brand);
        }

        [HttpPost]
        public JsonResult Add(Product model)
        {
            if (model.BrandId==0)
            {
                return Json("3");
            }
            try
            {
                if (model.BuyingPrice != 0 && model.SalesPrice != 0 && model.Kdv != 0)
                {
                    model.CreateDate = DateTime.Now;
                    productService.Add(model);
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
                foreach (var productId in data)
                {
                    productService.Delete(productId);
                }
                return Json("1");
            }
            catch { return Json("0"); }
        }
        #endregion

        #region MyRegion
        public ActionResult Edit(int id)
        {
            var product = productService.GetProductById(id);
            ViewBag.Brand = brandService.GetAll();
            return View(product);
            //var urun = DB.Urun.Where(u => u.ID == id).FirstOrDefault();
            //ViewBag.Marka = DB.Marka.ToList();
            //return View(urun);
        }

        [HttpPost]
        public JsonResult Edit(Product model)
        {
            try
            {
                model.CreateDate = DateTime.Now;
                productService.Update(model);
                //var urun = DB.Urun.Where(u => u.ID == model.ID).FirstOrDefault();
                //urun.MarkaID = model.MarkaID;
                //urun.Ad = model.Ad;
                //urun.Adet = model.Adet;
                //urun.AlisFiyat = model.AlisFiyat;
                //urun.Kdv = model.Kdv;
                //urun.SatisFiyat = model.SatisFiyat;
                //DB.SaveChanges();
                return Json("1");
            }
            catch { return Json("0"); }
        }
        #endregion

        //public ActionResult SoldProducts()
        //{
        //    return View();
        //}

    }
}
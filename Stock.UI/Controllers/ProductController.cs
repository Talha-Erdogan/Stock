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

        private readonly ProductService productService;
        private readonly BrandService brandService;
        public ProductController()
        {
            productService = new ProductService();
            brandService = new BrandService();
        }

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

        //public ActionResult SoldProducts()
        //{
        //    return View();
        //}

    }
}
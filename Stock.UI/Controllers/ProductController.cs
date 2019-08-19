using Stock.Business;
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
        public ProductController()
        {
            productService = new ProductService();
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
        public ActionResult SoldProducts()
        {
            return View();
        }
        
    }
}
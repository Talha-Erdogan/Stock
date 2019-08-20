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
    public class SalesController : Controller
    {
        #region Private Member
        SalesService salesService;
        ProductService productService;
        PersonalService personalService;
        BrandService brandService;
        CustomerService customerService;
        #endregion

        #region Constructor
        public SalesController()
        {
            salesService = new SalesService();
            productService = new ProductService();
            personalService = new PersonalService();
            brandService = new BrandService();
            customerService = new CustomerService();
        }
        #endregion

        #region List
        // GET: Sales
        public ActionResult Index()
        {
            ViewBag.Brand = brandService.GetAll();
            ViewBag.Customer = customerService.GetAll();
            return View();
        }

        public JsonResult List()
        {
            return this.Json(
            new
            {
                Result = (from p in productService.GetAll()
                          join b in brandService.GetAll() on p.BrandId equals b.Id
                          
                          select new
                          {
                              Id = p.Id,
                              Brand = b.Name,
                              Name = p.Name,
                              Piece = p.Piece,
                              SalesPrice = p.SalesPrice
                          })
            }, JsonRequestBehavior.AllowGet
            );
        }

        #endregion

        #region Sales
        [HttpPost]
        public JsonResult Sell(Array[] data, string discount, string customerId)
        {
            if (Convert.ToInt32(customerId)<=0)
            {
                return Json("2");
            }
            try
            {
                Sales sales = new Sales();
                int count = 0;
                sales.SalesDate = DateTime.Now;
                sales.Discount= Convert.ToDouble(discount) / Convert.ToDouble(data.Length);
                sales.PersonalId = Convert.ToInt32(Request.Cookies["Personal"]["Id"]);
                if (customerId != "-1") sales.CustomerId = Convert.ToInt32(customerId);
                for (int i = 0; i < data.Length; i++)
                {
                    foreach (var product in data[i])
                    {
                        if (count == 0)
                            sales.ProductId = Convert.ToInt32(product);
                        else if (count == 1)
                            sales.Piece = Convert.ToInt32(product);
                        count++;
                    }
                    count = 0;
                    salesService.Add(sales);
                }
                return Json("1");
            }
            catch { return Json("0"); }
        }
        #endregion

        #region MyRegion
        [HttpPost]
        public JsonResult Debt(Array[] data, string discount, string customerId, string debt)
        {
            if (Convert.ToInt32(customerId) <= 0)
            {
                return Json("2");
            }
            try
            {
                Sales sales = new Sales();
                int count = 0;
                sales.SalesDate = DateTime.Now;
                sales.Discount = Convert.ToDouble(discount) / Convert.ToDouble(data.Length);
                sales.PersonalId = Convert.ToInt32(Request.Cookies["Personal"]["Id"]);
                if (customerId != "-1")
                {
                    sales.CustomerId = Convert.ToInt32(customerId);
                    var cstm = customerService.GetCustomerById(sales.CustomerId);
                    cstm.Debt = cstm.Debt + Convert.ToDouble(debt);
                    customerService.Update(cstm);
                }
                for (int i = 0; i < data.Length; i++)
                {
                    foreach (var product in data[i])
                    {
                        if (count == 0)
                            sales.ProductId = Convert.ToInt32(product);
                        else if (count == 1)
                            sales.Piece = Convert.ToInt32(product);
                        count++;
                    }
                    count = 0;
                    salesService.Add(sales);
                }
                return Json("1");
            }
            catch { return Json("0"); }
        }
        #endregion

    }
}
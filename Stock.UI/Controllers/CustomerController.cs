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
    public class CustomerController : Controller
    {
        #region Private Member
        private readonly CustomerService customerService;
        #endregion
        #region Constructor
        public CustomerController()
        {
            customerService = new CustomerService();
        }
        #endregion
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
                Result = (from cus in customerService.GetAll()
                          select new
                          {
                              Id = cus.Id,
                              Debt = cus.Debt,
                              Name = cus.Name,
                              Surname = cus.Surname,
                              Phone = cus.Phone,
                              Address = cus.Address,
                          })
            }, JsonRequestBehavior.AllowGet);
        }
    }
}
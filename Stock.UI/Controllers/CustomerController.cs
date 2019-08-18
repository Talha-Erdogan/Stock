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
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}
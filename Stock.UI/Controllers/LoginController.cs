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
    public class LoginController : Controller
    {
        private UserService userService;
        private PersonalService personalService;
        private AuthorityService authorityService;
        public LoginController()
        {
            userService = new UserService();
            personalService = new PersonalService();
            authorityService = new AuthorityService();
        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Login(string userName, string password, bool rememberMe)
        {
            try
            {
                if (userName != null && password != null)
                {
                    var cryptoPassword = CryptoHelper.Conversion(password);
                    var userInformation = userService.GetUserInformationByUserNameAndPassword(userName, cryptoPassword);
                    if (userInformation != null)
                    {
                        HttpCookie loginUser = new HttpCookie("Personal");
                        loginUser.Values.Add("Id", userInformation.PersonalId.ToString());
                        loginUser.Values.Add("Name", userInformation.Name);
                        loginUser.Values.Add("Surname", userInformation.Surname);
                        loginUser.Values.Add("Image", userInformation.Image);
                        loginUser.Values.Add("EntryDate", userInformation.EntryDate.ToString());
                        loginUser.Values.Add("Yetki", userInformation.AuthorityName);
                        if (rememberMe)
                            loginUser.Expires = DateTime.Now.AddDays(365);
                        Response.Cookies.Add(loginUser);
                        return Json("1");
                    }
                    return Json("0");
                }
                return Json("0");
            }
            catch { return Json("0"); }
        }

        public ActionResult Logout()
        {
            if (Request.Cookies["Personal"] != null)
            {
                Response.Cookies["Personal"].Expires = DateTime.Now.AddDays(-1);
            }
            return Redirect("Index");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Stock.UI.Helper
{
    public class AppAuthorize : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var cookie = filterContext.HttpContext.Request.Cookies["Personal"];
            if (cookie == null)
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
            else
            {
                string controllerName = filterContext.RouteData.Values["controller"].ToString();
                if (cookie["Authority"] == "Personal" && controllerName == "Admin")
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Sales" }, { "action", "Index" } });
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
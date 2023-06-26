using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebAppTest.App_Start
{
    public class Authorize : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext) 
        {
            var session = HttpContext.Current.Session["user"];
            if (session != null)
            {
                return;
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    Controller = "Home",
                    Action = "Index",
                    returnUrl = filterContext.RequestContext.HttpContext.Request.RawUrl
                }));
            }    
        }
    }
}
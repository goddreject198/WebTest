using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppTest.Controllers
{
    public class MyCVController : Controller
    {
        // GET: MyCV
        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login", "Home");
            }    
            else
                return View();
        }
    }
}
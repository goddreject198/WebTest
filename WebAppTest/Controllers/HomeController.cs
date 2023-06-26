using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WebAppTest.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login");
            }    
            else
            {
                return View();
            }    
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string user, string pwd)
        {
            if (user.ToLower() == "admin" && pwd == "122") 
            {
                Session["user"] = user;
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "Login failed!";
                return View();
            }    
        }

        public ActionResult Logout()
        {
            Session.Remove("user");
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}
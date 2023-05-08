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
            return View();
        }
    }
}
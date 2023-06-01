using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppTest.Controllers
{
    public class ClockController : Controller
    {
        // GET: Clock
        public ActionResult Index()
        {
            return View();
        }
    }
}
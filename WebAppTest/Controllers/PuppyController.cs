using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppTest.Controllers
{
    public class PuppyController : Controller
    {
        // GET: Puppy
        public ActionResult Index()
        {
            return View();
        }
    }
}
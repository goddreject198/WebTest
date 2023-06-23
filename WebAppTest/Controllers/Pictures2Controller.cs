using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppTest.Models;

namespace WebAppTest.Controllers
{
    public class Pictures2Controller : Controller
    {
        // GET: Pictures2
        public ActionResult Index()
        {
            var list_pictures = new Pictures().Init().ToList();
            return View(list_pictures);
        }
    }
}
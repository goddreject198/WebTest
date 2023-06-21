using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppTest.Models;

namespace WebAppTest.Controllers
{
    public class PicturesController : Controller
    {
        // GET: Pictures
        public ActionResult Index()
        {
            var list_pictures = new Pictures().Init().ToList();
            ViewBag.ListPic = list_pictures;
            return View(list_pictures);
        }
    }
}
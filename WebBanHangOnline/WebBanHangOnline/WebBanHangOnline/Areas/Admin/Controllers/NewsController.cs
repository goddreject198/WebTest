using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.Areas.Admin.Controllers
{
    public class NewsController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Admin/News
        public ActionResult Index()
        {
            var news = _db.News.OrderByDescending(x => x.Id).ToList();
            return View(news);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(News model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedDate = DateTime.Now;
                model.ModifiedDate = DateTime.Now;
                model.Alias = Models.Common.Filter.FilterChar(model.Title);
                model.CategoryId = 1;
                _db.News.Add(model);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
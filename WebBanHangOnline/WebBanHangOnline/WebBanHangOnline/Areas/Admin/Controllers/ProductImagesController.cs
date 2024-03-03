using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.Areas.Admin.Controllers
{
    public class ProductImagesController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Admin/ProductImages
        public ActionResult Index(int Id)
        {
            ViewBag.ProductId = Id;
            var items = _db.ProductImages.Where(x => x.ProductId == Id).ToList();
            return View(items);
        }

        [HttpPost]
        public ActionResult AddImage(int productId, string url)
        {
            _db.ProductImages.Add(new ProductImage { 
                ProductId = productId, 
                Image = url,
                IsDefault = false
            });
            _db.SaveChanges();
            return Json(new { success = true });
        }

        [HttpPost]
        public ActionResult Delete(int Id) {
            var item = _db.ProductImages.Find(Id);
            _db.ProductImages.Remove(item);
            _db.SaveChanges();
            return Json(new {success = true});
        }

    }
}
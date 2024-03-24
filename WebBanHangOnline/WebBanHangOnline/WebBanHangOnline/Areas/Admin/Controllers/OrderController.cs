using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;
using PagedList;

namespace WebBanHangOnline.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Admin/Order
        public ActionResult Index(int? page)
        {
            var items = _db.Orders.OrderByDescending(x=>x.CreatedDate).ToList();
            if (page == null)
            {
                page = 1;
            }
            var pageNumber = page ?? 1;
            var pageSize = 5;
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(items.ToPagedList(pageNumber, pageSize));
        }


        public ActionResult View(int id)
        {
            var item = _db.Orders.Find(id);
            return View(item);
        }

        public ActionResult Partial_SanPham(int id) 
        {
            var item = _db.OrderDetails.Where(x => x.OrderId == id).ToList();
            return PartialView(item);
        }

        [HttpPost]
        public ActionResult UpdateStatus(int id, int trangthai)
        {
            var item = _db.Orders.Find(id);
            if (item != null)
            {
                _db.Orders.Attach(item);
                item.TypePayment = trangthai;
                _db.Entry(item).Property(x=>x.TypePayment).IsModified = true;
                _db.SaveChanges();
                return Json(new { Success = true, message = "Success" });
            }
            return Json(new { Success = false, message = "False" });
        }
    }
}
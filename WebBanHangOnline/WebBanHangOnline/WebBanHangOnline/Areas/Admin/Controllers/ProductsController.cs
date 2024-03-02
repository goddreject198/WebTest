using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Admin/Products
        public ActionResult Index(string searchText, int? page)
        {
            var pageSize = 10;
            if (page == null)
            {
                page = 1;
            }
            IEnumerable<Product> product = _db.Products.OrderByDescending(x => x.Id);
            if (!string.IsNullOrEmpty(searchText))
            {
                product = product.Where(x => x.Alias.Equals(searchText) || x.Alias.Contains(searchText));
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            product = product.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(product);
        }

        public ActionResult Add()
        {
            ViewBag.ProductCategory = new SelectList(_db.ProductCategories.ToList(),"Id","Title");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Product model)
        {
            if (ModelState.IsValid)
            {
                //model.CreatedDate = DateTime.Now;
                //model.ModifiedDate = DateTime.Now;
                //model.Alias = Models.Common.Filter.FilterChar(model.Title);
                //model.CategoryId = 1;
                //_db.News.Add(model);
                //_db.SaveChanges();
                //return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
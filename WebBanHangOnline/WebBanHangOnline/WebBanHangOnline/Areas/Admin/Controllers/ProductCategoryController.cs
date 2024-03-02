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
    public class ProductCategoryController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Admin/ProductCategory
        public ActionResult Index(string searchText, int? page)
        {
            var pageSize = 10;
            if (page == null)
            {
                page = 1;
            }
            IEnumerable<ProductCategory> product_Cat = _db.ProductCategories.OrderByDescending(x => x.Id);
            if (!string.IsNullOrEmpty(searchText))
            {
                product_Cat = product_Cat.Where(x => x.Alias.Equals(searchText) || x.Alias.Contains(searchText));
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            product_Cat = product_Cat.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(product_Cat);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ProductCategory model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedDate = DateTime.Now;
                model.ModifiedDate = DateTime.Now;
                model.Alias = Models.Common.Filter.FilterChar(model.Title);
                _db.ProductCategories.Add(model);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
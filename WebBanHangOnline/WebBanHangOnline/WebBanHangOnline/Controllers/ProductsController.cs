﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;

namespace WebBanHangOnline.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Products
        public ActionResult Index(int? id)
        {
            var items = _db.Products.ToList();
            if (id != null)
            {
                items = items.Where(x => x.ProductCategoryId == id).ToList();
            }    
            return View(items);
        }

        public ActionResult Detail (string alias, int id)
        {
            var item = _db.Products.Find(id);
            if (item != null)
            {
                _db.Products.Attach(item);
                item.ViewCount = item.ViewCount + 1;
                _db.Entry(item).Property(x=>x.ViewCount).IsModified = true;
                _db.SaveChanges();
            }
            return View(item);
        }

        public ActionResult ProductCategory(string alias, int id)
        {
            var items = _db.Products.ToList();
            if (id > 0)
            {
                items = items.Where(x => x.ProductCategoryId == id).ToList();
            }
            var cate = _db.ProductCategories.Find(id);
            if (cate != null)
            {
                ViewBag.CateName = cate.Title;
            }
            ViewBag.CateId = id;
            return View(items);
        }

        public ActionResult Partial_ItemsByCateId()
        {
            var items = _db.Products.Where(x=>x.IsHome && x.IsActive).Take(12).ToList();
            return PartialView(items);
        }

        public ActionResult Partial_ProductSales()
        {
            var items = _db.Products.Where(x => x.IsSale && x.IsActive).Take(12).ToList();
            return PartialView(items);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.Controllers
{
    public class ShoppingCartController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: ShoppingCart
        public ActionResult Index()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null && cart.items.Any())
            {
                ViewBag.CheckCart = cart;
            }
            return View();
        }

        public ActionResult CheckOut()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null && cart.items.Any())
            {
                ViewBag.CheckCart = cart;
            }
            return View();
        }

        public ActionResult CheckOutSuccess()
        {
            return View();
        }

        public ActionResult Partial_Item_CheckOut()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null && cart.items.Any())
            {
                return PartialView(cart.items);
            }
            return PartialView();
        }

        public ActionResult Partial_Item_Cart()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null && cart.items.Any())
            {
                return PartialView(cart.items);
            }
            return PartialView();
        }

        public ActionResult ShowCount()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null && cart.items.Any())
            {
                return Json(new { Count = cart.items.Count }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { Count = 0}, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Partial_CheckOut()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckOut(OrderViewModel req)
        {
            var code = new { Success = false, Code = -1 };
            if (ModelState.IsValid)
            {
                ShoppingCart cart = (ShoppingCart)Session["Cart"];
                if (cart != null && cart.items.Any())
                {
                    Order order = new Order();
                    order.CustomerName = req.CustomerName;
                    order.Address = req.Address;
                    order.Phone = req.Phone;
                    order.Email = req.Email;
                    cart.items.ForEach(x=>order.OrderDetails.Add(new OrderDetail
                    {
                        ProductId = x.ProductId,
                        Quantity = x.Quantity,
                        Price = x.Price
                    }));
                    order.TotalAmount = cart.items.Sum(x => (x.Price * x.Quantity));
                    order.TypePayment = req.TypePayment;
                    order.CreatedDate = DateTime.Now;
                    order.CreatedBy = req.Phone;
                    order.ModifiedDate = DateTime.Now;
                    order.Code = "DH" + DateTime.Now.ToString("yyyyMMddhhmmss");
                    _db.Orders.Add(order);
                    _db.SaveChanges();

                    //send mail to cus
                    var strSanPham = "";
                    var thanhTien = decimal.Zero;
                    var tongTien = decimal.Zero;
                    foreach(var sp in cart.items)
                    {
                        strSanPham += "<tr>";
                        strSanPham += "<td>"+ sp.ProductName+"</td>";
                        strSanPham += "<td>"+ sp.Quantity+"</td>";
                        strSanPham += "<td>"+ WebBanHangOnline.Common.Common.FormatNumber(sp.Price, 0)+"</td>";
                        strSanPham += "</tr>";
                        thanhTien += sp.Price * sp.Quantity;

                    }
                    tongTien = thanhTien;
                    string contentCus = System.IO.File.ReadAllText(Server.MapPath("~/Content/templates/send2.html"));
                    contentCus = contentCus.Replace("{{MaDon}}", order.Code);
                    contentCus = contentCus.Replace("{{SanPham}}", strSanPham);
                    contentCus = contentCus.Replace("{{TenKhachHang}}", order.CustomerName);
                    contentCus = contentCus.Replace("{{Phone}}", order.Phone);
                    contentCus = contentCus.Replace("{{Email}}", order.Email);
                    contentCus = contentCus.Replace("{{NgayDat}}", order.CreatedDate.ToString("dd-MM-yyyy"));
                    contentCus = contentCus.Replace("{{DiaChiNhanHang}}", order.Address);
                    contentCus = contentCus.Replace("{{ThanhTien}}", WebBanHangOnline.Common.Common.FormatNumber(thanhTien, 0).ToString());
                    contentCus = contentCus.Replace("{{TongTien}}", WebBanHangOnline.Common.Common.FormatNumber(tongTien, 0).ToString());
                    WebBanHangOnline.Common.Common.SendMail("ShopOnline","Đơn hàng #" + order.Code, contentCus.ToString(),req.Email);

                    string contentAdmin = System.IO.File.ReadAllText(Server.MapPath("~/Content/templates/send1.html"));
                    contentAdmin = contentAdmin.Replace("{{Order_Link}}", "https://localhost:44366/admin/order/view/" + order.Id.ToString());
                    contentAdmin = contentAdmin.Replace("{{MaDon}}", order.Code);
                    contentAdmin = contentAdmin.Replace("{{SanPham}}", strSanPham);
                    contentAdmin = contentAdmin.Replace("{{TenKhachHang}}", order.CustomerName);
                    contentAdmin = contentAdmin.Replace("{{Phone}}", order.Phone);
                    contentAdmin = contentAdmin.Replace("{{Email}}", order.Email);
                    contentAdmin = contentAdmin.Replace("{{NgayDat}}", order.CreatedDate.ToString("dd-MM-yyyy"));
                    contentAdmin = contentAdmin.Replace("{{DiaChiNhanHang}}", order.Address);
                    contentAdmin = contentAdmin.Replace("{{ThanhTien}}", WebBanHangOnline.Common.Common.FormatNumber(thanhTien, 0).ToString());
                    contentAdmin = contentAdmin.Replace("{{TongTien}}", WebBanHangOnline.Common.Common.FormatNumber(tongTien, 0).ToString());
                    WebBanHangOnline.Common.Common.SendMail("ShopOnline", "Đơn hàng mới #" + order.Code, contentAdmin.ToString(), req.Email);

                    cart.ClearCart();
                    return RedirectToAction("CheckOutSuccess");
                }
            }
            return Json(code);
        }

        [HttpPost]
        public ActionResult AddToCart(int id, int quantity, int? count)
        {
            var code = new { Success = false, msg = "", code = -1 , count = 0};
            var _db = new ApplicationDbContext();
            var checkProduct = _db.Products.FirstOrDefault(x => x.Id == id);
            if (checkProduct != null)
            {
                ShoppingCart cart = (ShoppingCart)Session["Cart"];
                if (cart == null) { cart = new ShoppingCart(); }
                ShoppingCartItem item = new ShoppingCartItem
                {
                    ProductId = checkProduct.Id,
                    ProductName = checkProduct.Title,
                    CategoryName = checkProduct.ProductCategory.Title,
                    Alias = checkProduct.Alias,
                    Quantity = quantity
                };
                if (checkProduct.ProductImage.FirstOrDefault(x => x.IsDefault) != null)
                {
                    item.ProductImg = checkProduct.ProductImage.FirstOrDefault(x => x.IsDefault).Image;
                }
                item.Price = checkProduct.Price;
                if (checkProduct.PriceSale > 0)
                {
                    item.Price = (decimal)checkProduct.PriceSale;
                }
                item.TotalPrice = item.Quantity * item.Price;
                cart.AddToCart(item, quantity);
                Session["Cart"] = cart;
                code = new { Success = true, msg = "Thêm sản phẩm vào giỏ hàng thành công", code = 1, count = cart.items.Count};
            }
            return Json(code);
        }

        [HttpPost]
        public ActionResult Update(int id, int quantity)
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null && cart.items.Any())
            {
                cart.UpdateQuantity(id, quantity);
                return Json(new { Success = true });
            }
            return Json(new { Success = false });
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var code = new { Success = false, msg = "", code = -1, count = 0 };
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null && cart.items.Any()) 
            { 
                var checkProdduct = cart.items.FirstOrDefault(x=>x.ProductId == id);
                if (checkProdduct != null)
                {
                    cart.Remove(id);
                    code = new { Success = true, msg = "", code = 1, count = cart.items.Count };
                }
            }

            return Json(code);
        }

        [HttpPost]
        public ActionResult DeleteAll()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null && cart.items.Any())
            {
                cart.ClearCart();
                return Json(new { Success = true });
            }
            return Json(new { Success = false });
        }
    }
}
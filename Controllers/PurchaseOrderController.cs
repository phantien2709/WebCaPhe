using AspNetCoreHero.ToastNotification.Abstractions;
using doan.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace doan.Controllers
{
    public class PurchaseOrderController:Controller
    {
        private readonly StoreContext _context;
        public INotyfService _notyfyService { get; set; }
        public PurchaseOrderController(StoreContext context, INotyfService notifyService)
        {
            _context = context;
            _notyfyService = notifyService;
        }
        [HttpPost]
        public IActionResult IndexPurchaseOrder()
        {
            var cusId = HttpContext.Session.GetString("KhachHang");
            //cusId = "1";
            if (cusId != null)
            {
                StoreContext context = HttpContext.RequestServices.GetService(typeof(doan.Models.StoreContext)) as StoreContext;
                if (Request.Cookies["Cart"] != null)
                {
                    var cart = Request.Cookies["Cart"];
                    List<Cart> dataCart = JsonConvert.DeserializeObject<List<Cart>>(cart);
                    if (dataCart.Count > 0)
                    {
                        ViewBag.carts = dataCart;
                    }
                }
                ViewBag.nhavanchuyen = context.getNVC();
                return View();
            }
            else
            {
                //------------------------------------
                // Nho sua thanh link Login
                return Redirect("/Login/SignIn");
            }
                
        }
        [HttpPost]
        public IActionResult Order(string name, string phone, string address, int carrier)
        {
            if ((name.Length > 50 || address.Length > 50) || (phone.Length > 10 ))
            {
                _notyfyService.Error("Một số lỗi đã xảy ra. Có vẻ bạn đã nhập sai thông tin giao hàng.");
                return Redirect("/Cart/IndexCart");
            }
            StoreContext context = HttpContext.RequestServices.GetService(typeof(doan.Models.StoreContext)) as StoreContext;
            if (Request.Cookies["Cart"] != null)
            {
                var cart = Request.Cookies["Cart"];
                List<Cart> dataCart = JsonConvert.DeserializeObject<List<Cart>>(cart);
                if (dataCart.Count > 0)
                {
                    ViewBag.carts = dataCart;
                }

                var totalSum = 0;
                DateTime orderDate = DateTime.Now;
                foreach (var item in dataCart)
                {
                    totalSum += Convert.ToInt32(item.Soluong * item.sanpham.GiaTien);
                }
                var cus = HttpContext.Session.GetString("KhachHang");
                if (cus != null)
                {
                    int cusId = Convert.ToInt32(cus);
                    int orderId = context.insert_DDH(cusId, totalSum, orderDate,carrier);
                    if (orderId != 0)
                    {
                        foreach (var item in dataCart)
                        {
                            var sump = Convert.ToInt32(item.Soluong * item.sanpham.GiaTien);
                            var tmp = context.insert_CTDH(orderId, item.sanpham.MaSp, item.Soluong, sump);
                            if (tmp == 0)
                            {
                                _notyfyService.Error("Đã có lỗi xảy ra.");
                                return Redirect("/Error404/Page404");
                            }
                            var dataProductNew = context.Product_id(item.sanpham.MaSp);
                            var tmp1 = context.update_SanPham(item.sanpham.MaSp, dataProductNew.SoLuong - item.Soluong);
                        }
                        ViewData["MADDH"] = orderId;
                        Response.Cookies.Delete("Cart");
                    }
                    else
                    {
                        _notyfyService.Error("Đã có lỗi xảy ra.");
                        return Redirect("/Error404/Page404");
                    }
                }
                return View();
            }
            else
            {
                _notyfyService.Error("Đã có lỗi xảy ra.");
                return Redirect("/Error404/Page404");
            }
        } 
    }
}

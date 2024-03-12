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
    public class CartController: Controller
    {
        private readonly StoreContext _context;
        public INotyfService _notyfyService { get; set; }
        public CartController(StoreContext context, INotyfService notifyService)
        {
            _context = context;
            _notyfyService = notifyService;
        }
        // Xu ly Gio hang voi Cookie
        public IActionResult IndexCart()
        {
            if (Request.Cookies["thongbaoloigiohang"] != null)
            {
                ViewData["thongbaoloigiohang"] = "Giỏ hàng không có sản phẩm";
            }
            Response.Cookies.Delete("thongbaoloigiohang");
            StoreContext context = HttpContext.RequestServices.GetService(typeof(doan.Models.StoreContext)) as StoreContext;
            if (Request.Cookies["Cart"] != null)
            {
                var cart = Request.Cookies["Cart"];
                List<Cart> dataCart = JsonConvert.DeserializeObject<List<Cart>>(cart);
                if (dataCart.Count > 0)
                {
                    
                    for (int i = 0; i < dataCart.Count; i++)
                    {
                        Product dataProductNew = context.Product_id(dataCart[i].sanpham.MaSp);
                        if (dataProductNew.SoLuong <= 0)
                        {
                            _notyfyService.Error("Sản phẩm "+dataCart[i].sanpham.TenSp+" đã hết hàng.");
                            dataCart.RemoveAt(i);
                            i--;
                        }
                        else
                        {
                            if (dataProductNew.SoLuong < dataCart[i].Soluong)
                            {
                                _notyfyService.Success("Sản phẩm " + dataCart[i].sanpham.TenSp + " đã cập nhật lại số lượng.");
                                dataCart[i].Soluong = dataProductNew.SoLuong;
                            }
                        }
                        
                    }
                    if (dataCart.Count > 0)
                    {
                        Response.Cookies.Delete("Cart");
                        CookieOptions option = new CookieOptions();
                        option.Expires = DateTime.Now.AddDays(30);
                        Response.Cookies.Append("Cart", JsonConvert.SerializeObject(dataCart), option);
                        ViewBag.carts = dataCart;
                    }
                    else
                    {
                        Response.Cookies.Delete("Cart");
                    }
                }
            }
            return View();
        }
        [HttpPost]
        public IActionResult AddCart(int productId)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(doan.Models.StoreContext)) as StoreContext;

            if (Request.Cookies["Cart"] == null)
            {
                var product = context.Product_id(productId);
                if (product.SoLuong <= 0)
                {
                    _notyfyService.Error("Sản phẩm đã hết hàng.");
                    return Redirect("/Giohang/IndexCart");
                }
                string img = context.HinhAnhSP(productId)[0].LinkHinhAnh;
                List<Cart> listCart = new List<Cart>()
               {
                   new Cart
                   {
                       sanpham = product,
                       hinhanh = img,
                       Soluong = 1
                   }
               };
                
                CookieOptions option = new CookieOptions();
                option.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Append("Cart", JsonConvert.SerializeObject(listCart), option);
            }
            else
            {
                //var cart = HttpContext.Session.GetString("Cart");
                var cart = Request.Cookies["Cart"];
                List<Cart> dataCart = JsonConvert.DeserializeObject<List<Cart>>(cart);
                bool check = true;
                for (int i = 0; i < dataCart.Count; i++)
                {
                    if (dataCart[i].sanpham.MaSp == productId)
                    {
                        if (dataCart[i].sanpham.SoLuong == dataCart[i].Soluong)
                        {
                            _notyfyService.Error("Sản phẩm đã đạt số lượng tối đa.");
                            return Redirect("/Giohang/IndexCart");
                        }
                        dataCart[i].Soluong++;
                        check = false;
                    }
                }
                if (check)
                {
                    var product = context.Product_id(productId);
                    if (product.SoLuong <= 0)
                    {
                        _notyfyService.Error("Sản phẩm đã hết hàng.");
                        return Redirect("/Giohang/IndexCart");
                    }
                    string img = context.HinhAnhSP(productId)[0].LinkHinhAnh;
                    dataCart.Add(new Cart
                    {
                        sanpham = product,
                        hinhanh = img,
                        Soluong = 1
                    });
                }
                
                CookieOptions option = new CookieOptions();
                option.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Append("Cart", JsonConvert.SerializeObject(dataCart), option);
            }
            _notyfyService.Success("Thêm thành công.");
            
            return Redirect("/Giohang/IndexCart");
            
        }
        [HttpPost]
        public IActionResult DeleteCart(int productId)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(doan.Models.StoreContext)) as StoreContext;
            var cart = Request.Cookies["Cart"];
            if (cart != null)
            {
                List<Cart> dataCart = JsonConvert.DeserializeObject<List<Cart>>(cart);
                
                dataCart.RemoveAll(item => item.sanpham.MaSp == productId);
                CookieOptions option = new CookieOptions();
                option.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Append("Cart", JsonConvert.SerializeObject(dataCart), option);

            }
            _notyfyService.Success("Xóa thành công.");
            return Redirect("/Giohang/IndexCart");
        }
        [HttpPost]
        public IActionResult MinusQuantity(int productId, int quantity)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(doan.Models.StoreContext)) as StoreContext;
            var cart = Request.Cookies["Cart"];
            if (cart != null)
            {
                List<Cart> dataCart = JsonConvert.DeserializeObject<List<Cart>>(cart);
                for (int i = 0; i < dataCart.Count; i++)
                {
                    if (dataCart[i].sanpham.MaSp == productId)
                    {
                        if (quantity<=1) dataCart.RemoveAt(i); 
                        else dataCart[i].Soluong = quantity-1;
                    }
                }
                CookieOptions option = new CookieOptions();
                option.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Append("Cart", JsonConvert.SerializeObject(dataCart), option);

            }
            return Redirect("/Giohang/IndexCart");
        }
        [HttpPost]
        public IActionResult PlusQuantity(int productId, int quantity)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(doan.Models.StoreContext)) as StoreContext;
            var cart = Request.Cookies["Cart"];
            if (cart != null)
            {
                List<Cart> dataCart = JsonConvert.DeserializeObject<List<Cart>>(cart);
                for (int i = 0; i < dataCart.Count; i++)
                {
                    if (dataCart[i].sanpham.MaSp == productId)
                    {
                        var dataNew = context.Product_id(dataCart[i].sanpham.MaSp);
                        if (dataNew.SoLuong == dataCart[i].Soluong)
                        {
                            _notyfyService.Error("Sản phẩm đã đạt số lượng tối đa.");
                            return Redirect("/Giohang/IndexCart");
                        }
                        else
                        {
                            dataCart[i].Soluong = quantity + 1;
                        }                        
                    }
                }
                CookieOptions option = new CookieOptions();
                option.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Append("Cart", JsonConvert.SerializeObject(dataCart), option);

            }
            
            return Redirect("/Giohang/IndexCart");
        }
    }
}

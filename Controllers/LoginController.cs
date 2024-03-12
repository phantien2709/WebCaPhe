using AspNetCoreHero.ToastNotification.Abstractions;
using doan.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace doan.Controllers
{
    public class LoginController:Controller
    {
        private readonly StoreContext _context;
        public INotyfService _notyfyService { get; set; }
        public LoginController(StoreContext context, INotyfService notifyService)
        {
            _context = context;
            _notyfyService = notifyService;
        }
        [HttpGet]
        public IActionResult SignIn()
        {
            var cusId = HttpContext.Session.GetString("KhachHang");
            if (cusId != null)
            {
                _notyfyService.Warning("Bạn đã đăng nhập. Hãy đăng xuất trước khi thực hiện nếu muốn.");
                return Redirect("/Home/Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult SignUp()
        {
            var cusId = HttpContext.Session.GetString("KhachHang");
            if (cusId != null)
            {
                _notyfyService.Warning("Bạn đã đăng nhập. Hãy đăng xuất trước khi thực hiện nếu muốn.");
                return Redirect("/Home/Index");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Login(string phone, string pass)
        {
            var cusId = HttpContext.Session.GetString("KhachHang");
            StoreContext context = HttpContext.RequestServices.GetService(typeof(doan.Models.StoreContext)) as StoreContext;
            Account acc = context.GetTaikhoan(phone, pass);
            if (acc.MaTk != 0)
            {
                Roles role = context.GetRoles(acc.RoleId);
                if (role.RoleName.Equals("Khách hàng"))
                {
                    Customer cus = context.GetKhachHang(acc.SoDienThoai);
                    HttpContext.Session.SetString("KhachHang", cus.MaKh.ToString());
                    HttpContext.Session.SetString("TaiKhoan", acc.MaTk.ToString());
                }
                else
                {
                    return Redirect("/Admin");
                }
                _notyfyService.Success("Đăng nhập thành công.");
                return Redirect("/Home/Index");
            }
            else
            {
                _notyfyService.Error("Đăng nhập không thành công. Kiểm tra thông tin đăng nhập.");
                
                return RedirectToAction(nameof(SignIn));
            }            
        }
        [HttpPost]
        public IActionResult Register(string cusName, string phone, DateTime dob, string gender, string address, string pass, string confirmpass)
        {
            if ((cusName.Length > 50 || address.Length > 50) || (phone.Length > 10 || pass.Length > 20))
            {
                _notyfyService.Error("Một số lỗi đã xảy ra. Vui lòng đăng ký lại.");
                return Redirect("/Login/SignUp");
            }
            if (pass.Equals(confirmpass))
            {


                StoreContext context = HttpContext.RequestServices.GetService(typeof(doan.Models.StoreContext)) as StoreContext;
                Customer cus = context.GetKhachHang(phone);
                if (cus.MaKh != 0)
                {
                    _notyfyService.Error("Số điện thoại đã đăng ký. Vui lòng dùng số khác.");
                    return Redirect("/Login/SignUp");
                }
                else
                {
                    int check = context.insert_KhachHang(cusName, phone, dob, gender, address);
                    if (check != 0)
                    {
                        int tmp = context.insert_TaiKhoan(phone, pass);
                        if (tmp != 0)
                        {
                            Customer k = context.GetKhachHang(phone);
                            HttpContext.Session.SetString("TaiKhoan", tmp.ToString());
                            HttpContext.Session.SetString("KhachHang", k.MaKh.ToString());
                            _notyfyService.Success("Đăng ký thành công.");
                            return Redirect("/Home/Index");
                        }
                    }
                }
                _notyfyService.Error("Đăng nhập không thành công. Kiểm tra thông tin đăng nhập.");
                return Redirect("/Login/SignUp");
            }
            else
            {
                _notyfyService.Error("Xác nhận lại mật khẩu sai.");
                return Redirect("/Login/SignUp");
            }
        }
        public IActionResult Signout()
        {
            var cusId = HttpContext.Session.GetString("KhachHang");
            if (cusId == null)
            {
                _notyfyService.Warning("Bạn chưa đăng nhập.");
                return Redirect("/Home/Index");
            }
            HttpContext.Session.Remove("KhachHang");
            _notyfyService.Success("Đăng xuất thành công.");
            return Redirect("/Home/Index");
        }
    }
}

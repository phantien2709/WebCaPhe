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
    public class CustomerAccountController: Controller
    {
        private readonly StoreContext _context;
        public INotyfService _notyfyService { get; set; }
        public CustomerAccountController(StoreContext context, INotyfService notifyService)
        {
            _context = context;
            _notyfyService = notifyService;
        }
        [HttpGet]
        public IActionResult IndexAccount()
        {
            var cusId = HttpContext.Session.GetString("KhachHang");
            if (cusId == null)
            {
                _notyfyService.Warning("Bạn chưa đăng nhập.");
                return Redirect("/Home/Index");
            }
            else
            {
                StoreContext context = HttpContext.RequestServices.GetService(typeof(doan.Models.StoreContext)) as StoreContext;
                ViewBag.Khachhang = context.GetKhachHangbyid(Convert.ToInt32(cusId));
                ViewBag.Dondathang = context.GetDonHangbyidKH(Convert.ToInt32(cusId));
                return View();
            }            
        }
        [HttpPost]        
        public IActionResult ChangePass(string pass, string passwordtk, string confirmpasswordtk)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(doan.Models.StoreContext)) as StoreContext;
            var acc = HttpContext.Session.GetString("TaiKhoan");
            int accId = Convert.ToInt32(acc);
            if (pass.Equals(context.GetTaikhoanbyid(accId).MatKhau))
            {
                if (passwordtk.Equals(confirmpasswordtk))
                {
                    if (passwordtk.Length>20)
                    {
                        _notyfyService.Error("Đã có lỗi xảy ra.");
                        return Redirect("/CustomerAccount/IndexAccount");
                    }
                    var tmp = context.DoiPass(accId, passwordtk);
                    if (tmp != 0)
                    {
                        _notyfyService.Success("Đổi mật khẩu thành công.");
                    }
                    else
                    {
                        _notyfyService.Error("Đổi mật khẩu thất bại.");
                    }
                }
                else
                {
                    _notyfyService.Error("Xác nhận lại mật khẩu sai.");
                }
            }
            else
            {
                _notyfyService.Error("Mật khẩu hiện tại sai.");
            }
            return Redirect("/CustomerAccount/IndexAccount");
        }
    }
}

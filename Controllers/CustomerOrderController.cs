using doan.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace doan.Controllers
{
    public class CustomerOrderController:Controller
    {
        public IActionResult IndexCustomerOrder(int cusId)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(doan.Models.StoreContext)) as StoreContext;
            List<GioHang> list = new List<GioHang>();
            var detail = context.GetCtdhs(cusId);
            foreach(var item in detail)
            {
                list.Add(new GioHang() { 
                    sanpham =context.Product_id(item.MaSp),
                    Soluong = item.SoLuong,
                    hinhanh = context.HinhAnhSP(item.MaSp)[0].LinkHinhAnh
                });
            }
            ViewBag.donDH = list;
            ViewBag.madh = cusId;
            ViewBag.ddh = context.GetDonDHbyid(cusId);
            return View();
        }
    }
}

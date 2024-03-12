using doan.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace doan.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MetricController : Controller
    {
        private readonly StoreContext _context;

        public MetricController(StoreContext context)
        {
            _context = context;
        }

        public IActionResult ProductCategories()

        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(doan.Models.StoreContext)) as StoreContext;
            var listProCate = new SortedList<string, int>();
            listProCate = context.slSanPham_DanhMuc();
            ViewBag.ListDMSP = listProCate;
            return View();
        }
        public string test()

        {
            return "test";
        }


        public IActionResult MonthlyRevenue(int year)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(doan.Models.StoreContext)) as StoreContext;
            SortedList<string, int> listMonRev = _context.DanhSo_Thang();
            ViewBag.ListDTT = listMonRev;

            return View();
        }

        public IActionResult Top10Order()
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(doan.Models.StoreContext)) as StoreContext;
            List<PurchaseOrder> listOrder = context.get10_Dondathang();
            ViewBag.ListDH = listOrder;
            return View();

        }

        public IActionResult CarrierMetric()
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(doan.Models.StoreContext)) as StoreContext;
            var listCarrier = new SortedList<string, int>();
            listCarrier = context.TK_NhaVanChuyen();
            ViewBag.ListNVC = listCarrier;
            return View();
        }
        public IActionResult CustomerMetric()
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(doan.Models.StoreContext)) as StoreContext;
            var listCustomer = new SortedList<string, int>();
            listCustomer = context.GetKH_Loai();
            ViewBag.ListKH = listCustomer;
            return View();
        }
        public IActionResult DailyRevenue()
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(doan.Models.StoreContext)) as StoreContext;
            var listRevenue = new SortedList<string, int>();
            listRevenue = context.DanhSo_Ngay();
            ViewBag.ListDT = listRevenue;
            return View();
        }
    }
}

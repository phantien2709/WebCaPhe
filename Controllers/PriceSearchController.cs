using doan.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace doan.Controllers
{
    public class PriceSearchController : Controller
    {
        private readonly FivemenCoffeeContext _context;

        public PriceSearchController(FivemenCoffeeContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult PriceSearch(string productPrice)
        {
            List<Product> ls = new List<Product>();
            if (string.IsNullOrEmpty(productPrice) || productPrice.Length < 1)
            {
                return PartialView("ListTheoGia", null);
            }
            ls = _context.Products
                .AsNoTracking()
                .Include(a => a.MaDanhMucNavigation)
                .Include(a => a.MaNccNavigation)
                .Where(x => x.TenSp.Contains(productPrice))

                .OrderBy(x => x.TenSp)
                .Take(10)
                .ToList();
            if (ls == null)
            {
                return PartialView("ListTheoGia", null);

            }
            else
            {
                return PartialView("ListTheoGia", ls);

            }
        }
        
    }
}

using System; 
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using doan.Models;
using PagedList.Core;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace doan.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsAdminController : Controller
    {
        private readonly FivemenCoffeeContext _context;

        public INotyfService _notyfyService { get; set; }
        public ProductsAdminController(FivemenCoffeeContext context, INotyfService notifyService)
        {
            _context = context;
            _notyfyService = notifyService;
        }

        // GET: Admin/AdminSanphams


        public IActionResult Index(int page = 1, int cateId = 0)
        {
            var pageNumber = page;
            var pageSize = 20;
            List<Product> isProducts = new List<Product>();
            if (cateId != 0)
            {
                isProducts = _context.Sanpham
                .AsNoTracking()
                .Where(x=>x.MaDanhMuc==cateId)
                .Include(x => x.MaDanhMucNavigation)
                .Include(x => x.MaNccNavigation)
                .OrderBy(x => x.MaSp).ToList();
            }
            else
            {
                isProducts = _context.Sanpham
                .AsNoTracking()
                .Include(x => x.MaDanhMucNavigation)
                .Include(x => x.MaNccNavigation)
                .OrderBy(x => x.MaSp).ToList();
            }

            PagedList<Product> models = new PagedList<Product>(isProducts.AsQueryable(), pageNumber, pageSize);
            ViewBag.Currentmadanhmuc = cateId;
            ViewBag.CurrentPage = pageNumber;
            
            ViewData["Danhmuc"] = new SelectList(_context.Danhmucsp, "MaDanhMuc", "TenDanhMuc", cateId);

            ViewData["Supplier"] = new SelectList(_context.Nhacungcap, "MaNcc", "TenNcc");

            return View(models);
        }
        public IActionResult Filtter(int cateId = 0)
        {
            var url = $"/Admin/AdminSanphams?cateId={cateId}";
            if (cateId == 0)
            {
                url = $"/Admin/AdminSanphams";
            }
            return Json(new { status = "success", redirectUrl = url });
        }
        // GET: Admin/AdminSanphams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Sanpham
                .Include(s => s.MaDanhMucNavigation)
                .Include(s => s.MaNccNavigation)
                .FirstOrDefaultAsync(m => m.MaSp == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Admin/AdminSanphams/Create
        public IActionResult Create()
        {
            ViewData["Danhmuc"] = new SelectList(_context.Danhmucsp, "MaDanhMuc", "TenDanhMuc");
            ViewData["Supplier"] = new SelectList(_context.Nhacungcap, "MaNcc", "TenNcc");
            return View();
        }

        // POST: Admin/AdminSanphams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaSp,TenSp,GiaTien,SoLuong,MaDanhMuc,MoTa,MaNcc")] Product product)
        {
            if (product.TenSp == null || product.GiaTien == null || product.MoTa == null)
            {
                _notyfyService.Warning("Thêm không thành công, có giá trị chưa được nhập");


            } else
            if (ModelState.IsValid)
            {
                
                _context.Add(product);
                await _context.SaveChangesAsync();
                _notyfyService.Success("Tạo mới thành công");

                return RedirectToAction(nameof(Index));
            }
            
            ViewData["Danhmuc"] = new SelectList(_context.Danhmucsp, "MaDanhMuc", "TenDanhMuc", product.MaDanhMuc);
            ViewData["Supplier"] = new SelectList(_context.Nhacungcap, "MaNcc", "TenNcc", product.MaNcc);
            return View(product);
        }

        // GET: Admin/AdminSanphams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Sanpham.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["Danhmuc"] = new SelectList(_context.Danhmucsp, "MaDanhMuc", "TenDanhMuc", product.MaDanhMuc);
            ViewData["Supplier"] = new SelectList(_context.Nhacungcap, "MaNcc", "TenNcc", product.MaNcc);
            return View(product);
        }

        // POST: Admin/AdminSanphams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaSp,TenSp,GiaTien,SoLuong,MaDanhMuc,MoTa,MaNcc")] Product product)
        {
            if (id != product.MaSp)
            {
                return NotFound();
            }
            else if(product.TenSp == null || product.GiaTien == null || product.MoTa == null)
            {
                _notyfyService.Warning("Cập nhật không thành công, có giá trị chưa được nhập");


            } else
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                    _notyfyService.Success("Cập nhật thành công");

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.MaSp))
                    {
                        _notyfyService.Success("Đã có lỗi xảy ra");

                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Danhmuc"] = new SelectList(_context.Danhmucsp, "MaDanhMuc", "TenDanhMuc", product.MaDanhMuc);
            ViewData["Supplier"] = new SelectList(_context.Nhacungcap, "MaNcc", "TenNcc", product.MaNcc);
            return View(product);
        }

        // GET: Admin/AdminSanphams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Sanpham
                .Include(s => s.MaDanhMucNavigation)
                .Include(s => s.MaNccNavigation)
                .FirstOrDefaultAsync(m => m.MaSp == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Admin/AdminSanphams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Sanpham.FindAsync(id);
            _context.Sanpham.Remove(product);
            await _context.SaveChangesAsync();
            _notyfyService.Success("Xóa thành công");

            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Sanpham.Any(e => e.MaSp == id);
        }
    }
}

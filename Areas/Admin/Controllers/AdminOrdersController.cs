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
    public class AdminOrdersController : Controller
    {
        private readonly FivemenCoffeeContext _context;

        public INotyfService _notyfyService { get; set; }
        public AdminOrdersController(FivemenCoffeeContext context, INotyfService notifyService)
        {
            _context = context;
            _notyfyService = notifyService;
        }

        // GET: Admin/AdminOrders
        public IActionResult Index(int? page)
        {
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 20;
            var isOrders = _context.PurchaseOrders
                .AsNoTracking()
                .Include(x => x.MaKhNavigation)
                .Include(x => x.MaNvNavigation)
                .Include(x => x.MaNvcNavigation)
                .OrderBy(x => x.MaDdh);
            PagedList<PurchaseOrder> models = new PagedList<PurchaseOrder>(isOrders, pageNumber, pageSize);
            ViewBag.CurrentPage = pageNumber;
            return View(models);
        }

        // GET: Admin/AdminOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.PurchaseOrders
                .Include(d => d.MaKhNavigation)
                .Include(d => d.MaNvNavigation)
                .Include(d => d.MaNvcNavigation)
                .Include(d => d.MaVoucherNavigation)
                .FirstOrDefaultAsync(m => m.MaDdh == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Admin/AdminOrders/Create
        public IActionResult Create()
        {
            ViewData["MaKh"] = new SelectList(_context.Customers, "TenKh", "DiaChi");
            ViewData["MaNv"] = new SelectList(_context.Staffs, "MaNv", "ChucVu");
            ViewData["MaNvc"] = new SelectList(_context.Carriers, "MaNvc", "MaNvc");
            ViewData["MaVoucher"] = new SelectList(_context.Voucher, "MaVoucher", "TenVoucher");
            return View();
        }

        // POST: Admin/AdminOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaDdh,MaKh,MaVoucher,TongDonHang,SoTienGiam,ThanhTien,MaNv,NgayDatHang,MaNvc")] PurchaseOrder order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaKh"] = new SelectList(_context.Customers, "MaKh", "DiaChi", order.MaKh);
            ViewData["MaNv"] = new SelectList(_context.Staffs, "MaNv", "ChucVu", order.MaNv);
            ViewData["MaNvc"] = new SelectList(_context.Carriers, "MaNvc", "MaNvc", order.MaNvc);
            ViewData["MaVoucher"] = new SelectList(_context.Voucher, "MaVoucher", "TenVoucher", order.MaVoucher);
            return View(order);
        }

        // GET: Admin/AdminOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.PurchaseOrders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["MaKh"] = new SelectList(_context.Customers, "MaKh", "TenKh", order.MaKh);
            ViewData["MaNv"] = new SelectList(_context.Staffs, "MaNv", "TenNv", order.MaNv);
            ViewData["MaNvc"] = new SelectList(_context.Carriers, "MaNvc", "TenNvc", order.MaNvc);
            ViewData["MaVoucher"] = new SelectList(_context.Voucher, "MaVoucher", "TenVoucher", order.MaVoucher);
            return View(order);
        }

        // POST: Admin/AdminOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaDdh,MaKh,MaVoucher,TongDonHang,SoTienGiam,ThanhTien,MaNv,NgayDatHang,MaNvc")] PurchaseOrder order)
        {
            if (id != order.MaDdh)
            {
                return NotFound();
            }
            
            
            order.ThanhTien = order.TongDonHang - order.SoTienGiam;
            if (order.TongDonHang <= 0)
            {
                _notyfyService.Warning("Sửa không thành công: Tổng đơn hàng phải lớn hơn 0");
            }

            else if(order.SoTienGiam > order.TongDonHang || order.SoTienGiam <0)
            {
                _notyfyService.Warning("Sửa không thành công: Số tiền giảm không hợp lệ");

            }
            else
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.MaDdh))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaKh"] = new SelectList(_context.Customers, "MaKh", "DiaChi", order.MaKh);
            ViewData["MaNv"] = new SelectList(_context.Staffs, "MaNv", "ChucVu", order.MaNv);
            ViewData["MaNvc"] = new SelectList(_context.Carriers, "MaNvc", "MaNvc", order.MaNvc);
            ViewData["MaVoucher"] = new SelectList(_context.Voucher, "MaVoucher", "TenVoucher", order.MaVoucher);
            return View(order);
        }

        // GET: Admin/AdminOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.PurchaseOrders
                .Include(d => d.MaKhNavigation)
                .Include(d => d.MaNvNavigation)
                .Include(d => d.MaNvcNavigation)
                .Include(d => d.MaVoucherNavigation)
                .FirstOrDefaultAsync(m => m.MaDdh == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Admin/AdminOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.PurchaseOrders.FindAsync(id);
            _context.PurchaseOrders.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.PurchaseOrders.Any(e => e.MaDdh == id);
        }
    }
}

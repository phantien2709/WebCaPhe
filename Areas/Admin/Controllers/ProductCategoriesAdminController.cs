using System; 
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using doan.Models;
using PagedList.Core;

namespace doan.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductCategoriesAdminController : Controller
    {
        private readonly FivemenCoffeeContext _context;

        public ProductCategoriesAdminController(FivemenCoffeeContext context)
        {
            _context = context;
        }

        // GET: Admin/AdminDanhmucsps
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Category.ToListAsync());
        //}
        public IActionResult Index(int? page)
        {
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 20;
            var isProCategories = _context.Danhmucsp.AsNoTracking()
                .OrderBy(x => x.MaDanhMuc);
            PagedList<Category> models = new PagedList<Category>(isProCategories, pageNumber, pageSize);
            ViewBag.CurrentPage = pageNumber;
            return View(models);
        }

        // GET: Admin/AdminDanhmucsps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proCategories = await _context.Danhmucsp
                .FirstOrDefaultAsync(m => m.MaDanhMuc == id);
            if (proCategories == null)
            {
                return NotFound();
            }

            return View(proCategories);
        }

        // GET: Admin/AdminDanhmucsps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminDanhmucsps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaDanhMuc,TenDanhMuc,MoTa")] Category proCategories)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proCategories);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(proCategories);
        }

        // GET: Admin/AdminDanhmucsps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proCategories = await _context.Danhmucsp.FindAsync(id);
            if (proCategories == null)
            {
                return NotFound();
            }
            return View(proCategories);
        }

        // POST: Admin/AdminDanhmucsps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaDanhMuc,TenDanhMuc,MoTa")] Category proCategories)
        {
            if (id != proCategories.MaDanhMuc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proCategories);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductCategoriesExists(proCategories.MaDanhMuc))
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
            return View(proCategories);
        }

        // GET: Admin/AdminDanhmucsps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proCategories = await _context.Danhmucsp
                .FirstOrDefaultAsync(m => m.MaDanhMuc == id);
            if (proCategories == null)
            {
                return NotFound();
            }

            return View(proCategories);
        }

        // POST: Admin/AdminDanhmucsps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proCategories = await _context.Danhmucsp.FindAsync(id);
            _context.Danhmucsp.Remove(proCategories);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductCategoriesExists(int id)
        {
            return _context.Danhmucsp.Any(e => e.MaDanhMuc == id);
        }
    }
}

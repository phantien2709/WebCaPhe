using System; 
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using doan.Models;
using PagedList.Core;
using System.IO;
using doan.Helpper;
using Microsoft.AspNetCore.Http;

namespace doan.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminPicturesController : Controller
    {
        private readonly FivemenCoffeeContext _context;

        public AdminPicturesController(FivemenCoffeeContext context)
        {
            _context = context;
        }

        // GET: Admin/AdminPictures
        //public async Task<IActionResult> Index()
        //{
        //    var cuaHangDecorateContext = _context.Image.Include(h => h.MaSpNavigation);
        //    return View(await cuaHangDecorateContext.ToListAsync());
        //}
        public IActionResult Index(int? page)
        {
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 20;
            var isImages = _context.Hinhanh
                .AsNoTracking()
                .Include(x => x.MaSpNavigation)
                .OrderBy(x => x.MaHinhAnh);
            PagedList<Image> models = new PagedList<Image>(isImages, pageNumber, pageSize);
            ViewBag.CurrentPage = pageNumber;
            return View(models);
        }

        // GET: Admin/AdminPictures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var image = await _context.Hinhanh
                .Include(h => h.MaSpNavigation)
                .FirstOrDefaultAsync(m => m.MaHinhAnh == id);
            if (image == null)
            {
                return NotFound();
            }

            return View(image);
        }

        // GET: Admin/AdminPictures/Create
        public IActionResult Create()
        {
            
            ViewData["MaSp"] = new SelectList(_context.Sanpham, "MaSp", "TenSp");
            return View();
        }

        // POST: Admin/AdminPictures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaHinhAnh,LinkHinhAnh,MaSp")] Image image, IFormFile myfile)// Microsoft.AspNetCore.Http.IFormFile fLinkHinhAnh)
        {
            if (ModelState.IsValid)
            {
                if (myfile != null)
                {
                    string fullPath = Path.Combine(Directory.GetCurrentDirectory(),
                                        "wwwroot", "Image", myfile.FileName);
                    using (var file = new FileStream(fullPath, FileMode.Create))
                    {
                        myfile.CopyTo(file);
                    }
                }
                  image.LinkHinhAnh = myfile.FileName;

                //image.MaSpNavigation.TenSp = Utilities.ToTitleCase(image.MaSpNavigation.TenSp);
                //if (fLinkHinhAnh != null)
                //{
                //    string extension = Path.GetExtension(fLinkHinhAnh.FileName);
                //    string image = Utilities.SEOUrl(image.MaSpNavigation.TenSp) + extension;
                //    image.LinkHinhAnh = await Utilities.UploadFile(fLinkHinhAnh, @"Hinh_anh_san_pham", extension.ToLower());
                //}
                //if (string.IsNullOrEmpty(image.LinkHinhAnh)) image.LinkHinhAnh = "default.jpg";
                _context.Add(image);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaSp"] = new SelectList(_context.Sanpham, "MaSp", "TenSp", image.MaSp);
            return View(image);
        }

        // GET: Admin/AdminPictures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var image = await _context.Hinhanh.FindAsync(id);
            if (image == null)
            {
                return NotFound();
            }
            ViewData["MaSp"] = new SelectList(_context.Sanpham, "MaSp", "TenSp", image.MaSp);
            return View(image);
        }

        // POST: Admin/AdminPictures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaHinhAnh,LinkHinhAnh,MaSp")] Image image)
        {
            if (id != image.MaHinhAnh)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(image);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImageExists(image.MaHinhAnh))
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
            ViewData["MaSp"] = new SelectList(_context.Sanpham, "MaSp", "TenSp", image.MaSp);
            return View(image);
        }

        // GET: Admin/AdminPictures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var image = await _context.Hinhanh
                .Include(h => h.MaSpNavigation)
                .FirstOrDefaultAsync(m => m.MaHinhAnh == id);
            if (image == null)
            {
                return NotFound();
            }

            return View(image);
        }

        // POST: Admin/AdminPictures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var image = await _context.Hinhanh.FindAsync(id);
            _context.Hinhanh.Remove(image);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImageExists(int id)
        {
            return _context.Hinhanh.Any(e => e.MaHinhAnh == id);
        }
    }
}

using doan.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace doan.Controllers
{
    public class SearchController:Controller
    {
        [HttpGet]
        public IActionResult SearchProduct(string keyWord)
        {
            StoreContext context= HttpContext.RequestServices.GetService(typeof(doan.Models.StoreContext)) as StoreContext;
            try
            {
                if (keyWord == null) return Redirect("/Home/Index");
                else
                {
                    List<Sanpham> listProduct = context.sqlSearchSP(keyWord);
                    ViewData.Model = listProduct;
                    List<string> listImg = new List<string>();
                    foreach (var item in listProduct)
                    {
                        string str = context.HinhAnhSP(item.MaSp)[0].LinkHinhAnh;
                        listImg.Add(str);
                    }
                    ViewBag.HinhAnhSP = listImg;
                }
            } 
            catch (Exception)
            {
                return Redirect("/Error404/Page404");
            }
            return View();
        }
    }
}

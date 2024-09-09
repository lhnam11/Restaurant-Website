using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSauce.Models;
namespace WebSauce.Controllers
{
    public class LoaiSanPhamController : Controller
    {
        QLTAEntities db = new QLTAEntities();
        // GET: LoaiSanPham
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LoaiSanPhamPartial()
        {
            var listLSP = db.LOAISPs.ToList();
            return View(listLSP);
        }
        public ActionResult SanPhamTheoLoai(int maloai)
        {
            var listSP = db.SANPHAMs.Where(sp => sp.MALSP==maloai).ToList();
            if (listSP.Count == 0)
            {
                ViewBag.SanPham = "Không có sản phẩm nào thuộc loại này";
            }
            return View(listSP);
        }
    }
}
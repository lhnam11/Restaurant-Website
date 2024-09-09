using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSauce.Models;
namespace WebSauce.Controllers
{
    public class SanPhamController : Controller
    {
        QLTAEntities db = new QLTAEntities();
        // GET: SanPham
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SanPhamPartial(string search="", int page = 1, string sortOrder = "")
        {
            var listSP = db.SANPHAMs.Where(row =>row.TENSP.Contains(search)).ToList();
            switch (sortOrder)
            {
                case "TENSP":
                    listSP = listSP.OrderBy(row => row.TENSP).ToList();
                    break;
                case "MASP":
                    listSP = listSP.OrderBy(row => row.MASP).ToList();
                    break;
                case "DONGIA":
                     listSP = listSP.OrderBy(row => row.DONGIA).ToList();
                    break;
                case "MALSP":
                    listSP = listSP.OrderBy(row => row.MALSP).ToList();
                    break;
                default:
                    break;
            }

            int NoOfRecordPerPage = 6;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(listSP.Count) /
                Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * NoOfRecordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            listSP = listSP.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();
            return View(listSP);
        }
        public ActionResult XemChiTiet(int msp)
        {
            SANPHAM sp = db.SANPHAMs.Single(s => s.MASP == msp);
            if (sp == null)
            {
                return HttpNotFound();
            }
            return View(sp);
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSauce.Models;
namespace WebSauce.Controllers
{
    public class AdminController : Controller
    {
        QLTAEntities db = new QLTAEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult laydsSP()
        {
            var sp = from s in db.SANPHAMs select s;
            return View(sp);
        }
        [HttpGet]
        public SANPHAM laySP(int msp)
        {
            return db.SANPHAMs.FirstOrDefault(x => x.MASP == msp);
        }
        [HttpGet]
        public DONHANG layDH(int dh)
        {
            return db.DONHANGs.FirstOrDefault(x => x.MADH == dh);
        }



        [HttpGet]
        public ActionResult laydsAccount()
        {
            var acc = from Account in db.Accounts select Account;
            return View(acc);
        }

        [HttpGet]
        public ActionResult laydsdonhang()
        {
            var dh = from donhang in db.DONHANGs select donhang;
            return View(dh.ToList());
        }
        [HttpPost]
        public ActionResult Details(int msp)
        {
            var dtpd = db.SANPHAMs.Where(s => s.MASP == msp).First();
            return View(dtpd);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection, SANPHAM sp)
        {
            
            var s = collection["TENSP"];

            sp.TENSP = s;
            db.SANPHAMs.Add(sp);
            db.SaveChanges();
            return RedirectToAction("laydsSP");
        }
        public ActionResult Createacc()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Createacc(FormCollection collection, Account a)
        {           
            var acc = collection["HoTen"];
            a.HoTen = acc;
            db.Accounts.Add(a);
            db.SaveChanges();
            return RedirectToAction("laydsAccount", "Admin");
        }
        public ActionResult Createdh()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Createdh(FormCollection collection, DONHANG dh,KHACHHANG kh)
        {
            var dhh = collection["TENKH"];
            kh.TENKH = dhh;    
            db.DONHANGs.Add(dh);
            db.SaveChanges();
            return RedirectToAction("laydsdonhang", "Admin");       
        }

        public ActionResult Edit(int msp)
        {
            var sp = db.SANPHAMs.First(m => m.MASP == msp);
            return View(sp);
        }
        public ActionResult Editacc(int userid)
        {
            var acc = db.Accounts.First(a => a.UserID == userid);
            return View(acc);
        }
        public ActionResult Edithd(int dh)
        {
            var hdd = db.DONHANGs.First(a => a.MADH == dh);
            return View(hdd);
        }
        [HttpPost]
        public ActionResult Editacc(int userid, FormCollection collection)
        {
            var bh = db.Accounts.First(a => a.UserID == userid);
            var tenacc = collection["HoTen"];
            bh.UserID = userid;
            bh.HoTen = tenacc;
            UpdateModel(bh);
            db.SaveChanges();
            return Redirect("laydsAccount");
        }
        [HttpPost]
        public ActionResult Edithd(int dh, FormCollection collection)
        {
            KHACHHANG kh  = new KHACHHANG();
            var hdd = db.DONHANGs.First(d => d.MADH == dh);
            var khachhang = collection["TENKH"];
            hdd.MAKH = dh;
            kh.TENKH = khachhang;
            UpdateModel(hdd);
            db.SaveChanges();
            return RedirectToAction("laydsdonhang","Admin");
        }
        [HttpPost]
        public ActionResult Edit(int msp, FormCollection collection)
        {

            var bh = db.SANPHAMs.First(m => m.MASP == msp);
            var tensp = collection["TENSP"];
            bh.MASP = msp;
            bh.TENSP = tensp;

            UpdateModel(bh);
            db.SaveChanges();
            return RedirectToAction("laydsSP");

        }
        public ActionResult Deleteacc(int userid)
        {
            var acc = db.Accounts.First(a => a.UserID == userid);
            return View(acc);
        }
        public ActionResult Delete(int msp)
        {
            var sp = db.SANPHAMs.First(m => m.MASP == msp);
            return View(sp);
        }
        public ActionResult Deletedh(int dh)
        {
            var dhh = db.DONHANGs.First(x => x.MADH == dh);
            return View(dhh);
        }

        [HttpPost]
        public ActionResult Deletedh(int dh,  FormCollection collection)
        {
            var dhh = db.DONHANGs.Where(x => x.MADH == dh).First();
            db.DONHANGs.Remove(dhh);
            db.SaveChanges();
            return RedirectToAction("laydsdonhang","Admin");
        }

        [HttpPost]
        public ActionResult Delete(int msp, FormCollection collection)
        {
            var sp = db.SANPHAMs.Where(m => m.MASP == msp).First();
            db.SANPHAMs.Remove(sp);
            db.SaveChanges();
            return RedirectToAction("laydsSP");
        }
        [HttpPost]
        public ActionResult Deleteacc(int userid, FormCollection collection)
        {
            var acc = db.Accounts.Where(a => a.UserID == userid).First();
            db.Accounts.Remove(acc);
            db.SaveChanges();
            return RedirectToAction("laydsAccount");

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSauce.Models;

namespace WebSauce.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        QLTAEntities db = new QLTAEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult dangky()
        {
            return View();
        }
        [HttpPost]
        public ActionResult dangky(FormCollection collection, Account a)
        {
            var acc = collection["HoTen"];
            a.HoTen = acc;
            db.Accounts.Add(a);
            db.SaveChanges();
            return RedirectToAction("Login", "TaiKhoan");
        }
    }
}
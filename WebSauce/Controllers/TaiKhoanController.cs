using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSauce.Models;
namespace WebSauce.Controllers
{
    public class TaiKhoanController : Controller
    {
        QLTAEntities db = new QLTAEntities();
        // GET: TaiKhoan
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string pass)
        {
            if (username == null || pass == null)
            {
                return RedirectToAction("Login", "TaiKhoan");
            }
            else if (db.TaiKhoans.Any(tk => tk.username == username && tk.password == pass))
            {
                return RedirectToAction("laydsSP", "Admin");
            }
            else if (db.Accounts.Any(a => a.Email == username &&  a.MatKhau ==pass ))
            {
                return RedirectToAction("Index", "Home");
            }    
            else
            {
                return RedirectToAction("Login", "TaiKhoan");
            }
        }

        public ActionResult Logout()
        {

            return RedirectToAction("Index", "SanPham");
        }


    }
}
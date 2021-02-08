using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    [AllowAnonymous]
    public class AdminLoginController : Controller
    {
        // GET: AdminLogin
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(TBLADMIN p)
        {
            using (DBKUTUPHANEEntities2 dbkutuphaneEntities2 = new DBKUTUPHANEEntities2())
            {
                var bilgiler =
                    dbkutuphaneEntities2.TBLADMIN.FirstOrDefault(x => x.KULLANICI == p.KULLANICI && x.SIFRE == p.SIFRE);
                if (bilgiler != null)
                {
                    FormsAuthentication.SetAuthCookie(bilgiler.KULLANICI, false);
                    Session["KULLANICI"] = bilgiler.KULLANICI.ToString();
                    return RedirectToAction("Index", "Kategori");
                }
                else
                {
                    return View();
                }
            }
        }
    }
}
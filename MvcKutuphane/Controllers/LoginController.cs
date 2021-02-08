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
    public class LoginController : Controller
    {
        // GET: Login
        private DBKUTUPHANEEntities2 dbkutuphaneEntities2 = new DBKUTUPHANEEntities2();
        public ActionResult GirisYap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GirisYap(TBLUYELER p)
        {
            var bilgiler = dbkutuphaneEntities2.TBLUYELER.FirstOrDefault(x => x.MAIL == p.MAIL && x.SIFRE == p.SIFRE);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.MAIL, false);
                Session["Mail"] = bilgiler.MAIL;
                Session["Ad"] = bilgiler.AD;
                Session["Soyad"] = bilgiler.SOYAD;


                return RedirectToAction("Index", "Panelim");
            }
            else
            {
                return View();
            }
        }
    }
}
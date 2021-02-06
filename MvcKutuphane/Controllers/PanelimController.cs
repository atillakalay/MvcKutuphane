using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{

    public class PanelimController : Controller
    {
        // GET: Panelim
        private DBKUTUPHANEEntities2 dbkutuphaneEntities2 = new DBKUTUPHANEEntities2();
        [Authorize]

        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"];
            var degerler = dbkutuphaneEntities2.TBLUYELER.FirstOrDefault(z => z.MAIL == uyemail);
            return View(degerler);
        }
        [HttpPost]
        public ActionResult Index2(TBLUYELER p)
        {
            var kullanici = (string)Session["Mail"];
            var uye = dbkutuphaneEntities2.TBLUYELER.FirstOrDefault(x => x.MAIL == kullanici);
            uye.SIFRE = p.SIFRE;
            uye.AD = p.AD;
            uye.FOTOGRAF = p.FOTOGRAF;
            uye.OKUL = p.OKUL;
            uye.KULLANICIADI = p.KULLANICIADI;
            dbkutuphaneEntities2.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Kitaplarim()
        {
            var uyemail = (string)Session["Mail"];
            var id = dbkutuphaneEntities2.TBLUYELER.Where(x => x.MAIL == uyemail.ToString()).Select(z => z.ID).FirstOrDefault();
            var degerler = dbkutuphaneEntities2.TBLHAREKET.Where(x => x.UYE == id).ToList();
            return View(degerler);
        }

        public ActionResult Duyurular()
        {
            var duyurulistesi = dbkutuphaneEntities2.TBLDUYURULAR.ToList();
            return View(duyurulistesi);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap", "Login");
        }
    }
}
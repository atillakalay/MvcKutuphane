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
            //var degerler = dbkutuphaneEntities2.TBLUYELER.FirstOrDefault(z => z.MAIL == uyemail);
            var degerler = dbkutuphaneEntities2.TBLDUYURULAR.ToList();
            var d1 = dbkutuphaneEntities2.TBLUYELER.Where(x => x.MAIL == uyemail).Select(y => y.AD + " " + y.SOYAD).FirstOrDefault();
            ViewBag.d1 = d1;
            var d2 = dbkutuphaneEntities2.TBLUYELER.Where(x => x.MAIL == uyemail).Select(y => y.OKUL).FirstOrDefault();
            ViewBag.d2 = d2;
            var d3 = dbkutuphaneEntities2.TBLUYELER.Where(x => x.MAIL == uyemail).Select(y => y.FOTOGRAF).FirstOrDefault();
            ViewBag.d3 = d3;
            var d4 = dbkutuphaneEntities2.TBLUYELER.Where(x => x.MAIL == uyemail).Select(y => y.KULLANICIADI).FirstOrDefault();
            ViewBag.d4 = d4;
            var d5 = dbkutuphaneEntities2.TBLUYELER.Where(x => x.MAIL == uyemail).Select(y => y.MAIL).FirstOrDefault();
            ViewBag.d5 = d5;
            var d6 = dbkutuphaneEntities2.TBLUYELER.Where(x => x.MAIL == uyemail).Select(y => y.TELEFON).FirstOrDefault();
            ViewBag.d6 = d6;
            var uyeId = dbkutuphaneEntities2.TBLUYELER.Where(x => x.MAIL == uyemail).Select(y => y.ID).FirstOrDefault();
            var d7 = dbkutuphaneEntities2.TBLHAREKET.Count(x => x.UYE == uyeId);
            ViewBag.d7 = d7;
            var d8 = dbkutuphaneEntities2.TBLMESAJLAR.Count(x => x.ALICI == uyemail);
            ViewBag.d8 = d8;
            var d9 = dbkutuphaneEntities2.TBLDUYURULAR.Count();
            ViewBag.d9 = d9;

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

        public PartialViewResult Partial1()
        {
            return PartialView();
        }
        public PartialViewResult Partial2()
        {
            var mail = (string) Session["Mail"];
            var id = dbkutuphaneEntities2.TBLUYELER.Where(x => x.MAIL == mail).Select(y => y.ID).FirstOrDefault();
            var uyebul = dbkutuphaneEntities2.TBLUYELER.Find(id);
            return PartialView("Partial2",uyebul);
        }

    }
}
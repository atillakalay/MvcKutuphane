﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
    }
}
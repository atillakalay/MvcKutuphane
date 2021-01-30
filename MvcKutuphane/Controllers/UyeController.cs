﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
using PagedList;

namespace MvcKutuphane.Controllers
{
    public class UyeController : Controller
    {
        // GET: Uye
        private DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index(int sayfa = 1)
        {
            //var degerler = db.TBLUYELER.ToList();
            //var degerler = db.TBLUYELER.ToString().ToPagedList(sayfa,10);
            var degerler = db.TBLUYELER.ToList().ToPagedList(sayfa, 10);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult UyeEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UyeEkle(TBLUYELER p)
        {
            if (!ModelState.IsValid)
            {
                return View("UyeEkle");
            }
            db.TBLUYELER.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UyeSil(int id)
        {
            var uye = db.TBLUYELER.Find(id);
            db.TBLUYELER.Remove(uye);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UyeGetir(int id)
        {
            var uye = db.TBLUYELER.Find(id);
            return View("UyeGetir", uye);
        }

        public ActionResult UyeGuncelle(TBLUYELER p)
        {
            var uye = db.TBLUYELER.Find(p.ID);
            if (uye != null)
            {
                uye.AD = p.AD;
                uye.SOYAD = p.SOYAD;
                uye.MAIL = p.MAIL;
                uye.KULLANICIADI = p.KULLANICIADI;
                uye.SIFRE = p.SIFRE;
                uye.OKUL = p.OKUL;
                uye.TELEFON = p.TELEFON;
                uye.FOTOGRAF = p.FOTOGRAF;
            }

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
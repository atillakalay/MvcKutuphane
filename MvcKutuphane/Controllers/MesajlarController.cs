using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class MesajlarController : Controller
    {
        // GET: Mesajlar
        private DBKUTUPHANEEntities2 _dbkutuphaneEntities2 = new DBKUTUPHANEEntities2();
        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"];
            var mesajlar = _dbkutuphaneEntities2.TBLMESAJLAR.Where(x => x.ALICI == uyemail).ToList();
            return View(mesajlar);
        }
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(TBLMESAJLAR t)
        {
            var uyemail = (string)Session["Mail"];
            t.GONDEREN = uyemail;
            _dbkutuphaneEntities2.TBLMESAJLAR.Add(t);
            t.TARIH=DateTime.Parse(DateTime.Now.ToLongDateString());
            _dbkutuphaneEntities2.SaveChanges();
            return RedirectToAction("Giden");
        }
        public ActionResult Giden()
        {
            var uyemail = (string)Session["Mail"];
            var mesajlar = _dbkutuphaneEntities2.TBLMESAJLAR.Where(x => x.GONDEREN == uyemail).ToList();
            return View(mesajlar);
        }
    }
}
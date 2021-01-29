using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class OduncController : Controller
    {
        // GET: Odunc
        private DBKUTUPHANEEntities dbkutuphane = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var degerler = dbkutuphane.TBLHAREKET.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult Oduncver()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Oduncver(TBLHAREKET p)
        {
            dbkutuphane.TBLHAREKET.Add(p);
            dbkutuphane.SaveChanges();
            return RedirectToAction("Oduncver");
        }
    }
}
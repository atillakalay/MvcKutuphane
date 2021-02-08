using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models;

namespace MvcKutuphane.Controllers
{
    public class GrafikController : Controller
    {
        // GET: Grafik
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult VisualizeKitapResult()
        {
            return Json(liste());

        }

        public List<YayıneviDal> liste()
        {
            List<YayıneviDal> cs = new List<YayıneviDal>();
            cs.Add(new YayıneviDal()
            {
                yayinevi = "Güneş",
                sayi = 7
            });
            cs.Add(new YayıneviDal()
            {
                yayinevi = "Mars",
                sayi = 4
            });
            cs.Add(new YayıneviDal()
            {
                yayinevi = "Jupiter",
                sayi = 6
            });
            return cs;
        }
    }
}
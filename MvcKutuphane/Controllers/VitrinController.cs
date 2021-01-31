using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
using MvcKutuphane.Models.Siniflar;

namespace MvcKutuphane.Controllers
{
    public class VitrinController : Controller
    {
        // GET: Vitrin
        private DBKUTUPHANEEntities2 dBKUTUPHANE = new DBKUTUPHANEEntities2();

        [HttpGet]
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger1 = dBKUTUPHANE.TBLKITAP.ToList();
            cs.Deger2 = dBKUTUPHANE.TBLHAKKIMIZDA.ToList();
            return View(cs);
        }
        [HttpPost]
        public ActionResult Index(TBLILETISIM t)
        {
            dBKUTUPHANE.TBLILETISIM.Add(t);
            dBKUTUPHANE.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
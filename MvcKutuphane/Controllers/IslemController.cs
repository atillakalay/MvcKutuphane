using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{

    public class IslemController : Controller
    {
        private DBKUTUPHANEEntities dBKUTUPHANE = new DBKUTUPHANEEntities();
        // GET: Islem
        public ActionResult Index()
        {
            var degerler = dBKUTUPHANE.TBLHAREKET.Where(x => x.ISLEMDURUM == true).ToList();
            return View(degerler);
        }
    }
}
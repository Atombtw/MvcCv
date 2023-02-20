using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;

namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        DbCvEntities db = new DbCvEntities();
        public ActionResult Index()
        {
            var degerler = db.Tbl_Hakkimda.ToList();
            return View(degerler);
        }
        public PartialViewResult SosyalMedya()
        {
            var sosyalmedya = db.Tbl_SosyalMedya.Where(x => x.Durum == true).ToList();
            return PartialView(sosyalmedya);
        }
        public PartialViewResult Deneyim()
        {
            var deneyimler = db.Tbl_Deneyimler.ToList();
            return PartialView(deneyimler);
        }
        public PartialViewResult Egitim()
        {
            var egitimler = db.Tbl_Egitimlerim.ToList();
            return PartialView(egitimler);
        }
        public PartialViewResult Yetenek()
        {
            var yetenekler = db.Tbl_Yeteneklerim.ToList();
            return PartialView(yetenekler);
        }
        public PartialViewResult Hobi()
        {
            var hobiler = db.Tbl_Hobilerim.ToList();
            return PartialView(hobiler);
        }
        public PartialViewResult Sertifika()
        {
            var sertifikalar = db.Tbl_Sertifikalarim.ToList();
            return PartialView(sertifikalar);
        }
        [HttpGet]
        public PartialViewResult Iletisim()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Iletisim(Tbl_İletisim x)
        {
            x.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Tbl_İletisim.Add(x);
            db.SaveChanges();
            return PartialView();
        }
    }
}
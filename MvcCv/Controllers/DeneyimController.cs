using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class DeneyimController : Controller
    {
        // GET: Deneyim
        DeneyimRepository repo = new DeneyimRepository();
        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult DeneyimEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeneyimEkle(Tbl_Deneyimler p)
        {
            repo.XAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeneyimSil(int id)
        {
            Tbl_Deneyimler x = repo.Find(t => t.ID == id);
            repo.XDalete(x);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeneyimGetir(int id)
        {
            Tbl_Deneyimler x = repo.Find(t => t.ID == id);
            return View(x);
        }

        [HttpPost]
        public ActionResult DeneyimGetir(Tbl_Deneyimler p)
        {
            Tbl_Deneyimler x = repo.Find(t => t.ID == p.ID);
            x.Baslik = p.Baslik;
            x.AltBaslik = p.AltBaslik;
            x.Tarih = p.Tarih;
            x.Aciklama = p.Aciklama;
            repo.XUpdate(x);
            return RedirectToAction("Index");
        }
    }
}
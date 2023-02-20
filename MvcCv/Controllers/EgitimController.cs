using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class EgitimController : Controller
    {
        // GET: Egitim
        GenericRepository<Tbl_Egitimlerim> repo = new GenericRepository<Tbl_Egitimlerim>();
        public ActionResult Index()
        {
            var x = repo.List();
            return View(x);
        }

        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EgitimEkle(Tbl_Egitimlerim p)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimEkle");
            }
            repo.XAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult EgitimSil(int id)
        {
            var t = repo.Find(x => x.ID == id);
            repo.XDalete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EgitimGetir(int id)
        {
            var t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult EgitimGetir(Tbl_Egitimlerim p)
        {
            var t = repo.Find(x => x.ID == p.ID);
            t.Baslik = p.Baslik;
            t.AltBaslik1 = p.AltBaslik1;
            t.AltBaslik2 = p.AltBaslik2;
            t.Tarih = p.Tarih;
            t.GNO = p.GNO;
            repo.XUpdate(t);
            return RedirectToAction("Index");
        }
    }
}
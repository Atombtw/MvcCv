using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class SosyalMedyaController : Controller
    {
        // GET: SosyalMedya
        GenericRepository<Tbl_SosyalMedya> repo = new GenericRepository<Tbl_SosyalMedya>();
        public ActionResult Index()
        {
            var x = repo.List();
            return View(x);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Tbl_SosyalMedya p)
        {
            repo.XAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Duzenle(int id)
        {
            var t = repo.Find(x => x.ID == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult Duzenle(Tbl_SosyalMedya p)
        {
            var t = repo.Find(x => x.ID == p.ID);
            t.Durum = true;
            t.Ad = p.Ad;
            t.Link = p.Link;
            t.Ikon = p.Ikon;
            repo.XUpdate(t);
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var t = repo.Find(x => x.ID == id);
            t.Durum = false;
            repo.XUpdate(t);
            return RedirectToAction("Index");
        }
    }
}
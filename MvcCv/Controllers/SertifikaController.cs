using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class SertifikaController : Controller
    {
        // GET: Sertifika
        GenericRepository<Tbl_Sertifikalarim> repo = new GenericRepository<Tbl_Sertifikalarim>();
        public ActionResult Index()
        {
            var x = repo.List();
            return View(x);
        }

        [HttpGet]
        public ActionResult SertifikaGetir(int id)
        {
            var i = repo.Find(x => x.ID == id);
            ViewBag.d = i.ID;
            return View(i);
        }

        [HttpPost]
        public ActionResult SertifikaGetir(Tbl_Sertifikalarim p)
        {
            var i = repo.Find(x => x.ID == p.ID);
            i.Aciklama = p.Aciklama;
            i.Tarih = p.Tarih;
            repo.XUpdate(i);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult YeniSertifika()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniSertifika(Tbl_Sertifikalarim p)
        {
            repo.XAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult SertifikaSil(int id)
        {
            var t = repo.Find(x => x.ID == id);
            repo.XDalete(t);
            return RedirectToAction("Index");
        }
    }
}
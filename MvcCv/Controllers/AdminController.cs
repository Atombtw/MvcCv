using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        GenericRepository<Tbl_Admin> repo = new GenericRepository<Tbl_Admin>();
        public ActionResult Index()
        {
            var t = repo.List();
            return View(t);
        }

        [HttpGet]
        public ActionResult AdminEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminEkle(Tbl_Admin p)
        {
            repo.XAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult AdminSil(int id)
        {
            Tbl_Admin x = repo.Find(t => t.ID == id);
            repo.XDalete(x);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AdminDuzenle(int id)
        {
            Tbl_Admin x = repo.Find(t => t.ID == id);
            return View(x);
        }

        [HttpPost]
        public ActionResult AdminDuzenle(Tbl_Admin p)
        {
            Tbl_Admin x = repo.Find(t => t.ID == p.ID);
            x.KullaniciAdi = p.KullaniciAdi;
            x.Sifre = p.Sifre;
            repo.XUpdate(x);
            return RedirectToAction("Index");
        }
    }
}
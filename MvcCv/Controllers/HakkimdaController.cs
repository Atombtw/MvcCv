using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class HakkimdaController : Controller
    {
        // GET: Hakkimda
        GenericRepository<Tbl_Hakkimda> repo = new GenericRepository<Tbl_Hakkimda>();
        [HttpGet]
        public ActionResult Index()
        {
            var x = repo.List();
            return View(x);
        }

        [HttpPost]
        public ActionResult Index(Tbl_Hakkimda p)
        {
            var t = repo.Find(x => x.ID == 1);
            t.Ad = p.Ad;
            t.Soyad = p.Soyad;
            t.Adres = p.Adres;
            t.Mail = p.Mail;
            t.Telefon = p.Telefon;
            t.Aciklama = p.Aciklama;
            t.Resim = p.Resim;
            repo.XUpdate(t);
            return RedirectToAction("Index");
        }
    }
}
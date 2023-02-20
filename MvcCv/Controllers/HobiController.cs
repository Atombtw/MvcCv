using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class HobiController : Controller
    {
        // GET: Hobi
        GenericRepository<Tbl_Hobilerim> repo = new GenericRepository<Tbl_Hobilerim>();
        [HttpGet]
        public ActionResult Index()
        {
            var x = repo.List();
            return View(x);
        }

        [HttpPost]
        public ActionResult Index(Tbl_Hobilerim p)
        {
            var t = repo.Find(x => x.ID == 1);
            t.Aciklama1 = p.Aciklama1;
            t.Aciklama2 = p.Aciklama2;
            repo.XUpdate(t);
            return RedirectToAction("Index");
        }
    }
}
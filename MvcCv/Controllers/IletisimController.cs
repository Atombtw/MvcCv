using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class IletisimController : Controller
    {
        // GET: Iletisim
        GenericRepository<Tbl_İletisim> repo = new GenericRepository<Tbl_İletisim>();
        public ActionResult Index()
        {
            var q = repo.List();
            return View(q);
        }
    }
}
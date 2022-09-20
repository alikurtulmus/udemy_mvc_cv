using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using udemy_mvc_cv.Models.Entity;
using udemy_mvc_cv.Repositories;

namespace udemy_mvc_cv.Controllers
{
    public class HobiController : Controller
    {
        // GET: Hobi

        GenericRepository<TblHobiler> repo = new GenericRepository<TblHobiler>();

        [HttpGet]
        public ActionResult Index()
        {
            var hobiler = repo.List();
            return View(hobiler);
        }

        [HttpPost]
        public ActionResult Index(TblHobiler p)
        {
            //TblHobiler t=new TblHobiler();
            var t = repo.Find(x => x.ID == 1);
            t.Aciklama1=p.Aciklama1;
            t.Aciklama2=p.Aciklama2;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }

    }
}
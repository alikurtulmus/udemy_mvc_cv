using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using udemy_mvc_cv.Models.Entity;
using udemy_mvc_cv.Repositories;

namespace udemy_mvc_cv.Controllers
{
    [Authorize]

    public class EgitimController : Controller
    {
        // GET: Egitim
        GenericRepository<TblEgitimler> repo = new GenericRepository<TblEgitimler>();


        public ActionResult Index()
        {
            var egitim = repo.List();
            return View(egitim);
        }

        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EgitimEkle(TblEgitimler p)
        {
            if(!ModelState.IsValid)
            { return View("EgitimEkle"); }

            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult EgitimSil(int id)
        {
            var egitim=repo.Find(x=>x.ID==id);
            repo.TDelete(egitim);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult EgitimDuzenle(int id)
        {
            var egitim = repo.Find(x => x.ID == id);
            return View(egitim);
        }

        [HttpPost]
        public ActionResult EgitimDuzenle(TblEgitimler t)
        {
            if (!ModelState.IsValid)
            { return View("EgitimDuzenle"); }
            var egitim = repo.Find(x => x.ID == t.ID);
            egitim.Baslik = t.Baslik;
            egitim.AltBaslik1=t.AltBaslik1;
            egitim.AltBaslik2 = t.AltBaslik2;
            egitim.Tarih = t.Tarih;
            egitim.GNO = t.GNO;
            repo.TUpdate(egitim);
            return RedirectToAction("Index");
        }

    }
}
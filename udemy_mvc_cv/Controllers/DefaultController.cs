using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using udemy_mvc_cv.Models.Entity;

namespace udemy_mvc_cv.Controllers
{
    [AllowAnonymous]

    public class DefaultController : Controller
    {
        // GET: Default

        udemy_mvc_cvEntities db = new udemy_mvc_cvEntities();

        public ActionResult Index()
        {
            var degerler = db.TblHakkimdas.ToList();
            return View(degerler);
        }

        public PartialViewResult SosyalMedya()

        {
            var sosyalmedya = db.TblSosyalMedya.Where(x => x.Durum == true).ToList();
            return PartialView(sosyalmedya);
        }

        public PartialViewResult Deneyim()

        {
            var deneyimler = db.TblDeneyimlers.ToList();
            return PartialView(deneyimler);
        }

        public PartialViewResult Egitim()
        {
            var egitimler = db.TblEgitimlers.ToList();
            return PartialView(egitimler);
        }
        public PartialViewResult Yetenek()
        {
            var yetenekler = db.TblYeteneklers.ToList();
            return PartialView(yetenekler);
        }

        public PartialViewResult Hobi()
        {
            var hobiler = db.TblHobilers.ToList();
            return PartialView(hobiler);
        }
        public PartialViewResult Sertifika()
        {
            var sertifikalar = db.TblSertifikalars.ToList();
            return PartialView(sertifikalar);
        }

        [HttpGet]
        public PartialViewResult Iletisim()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult Iletisim(TblIletisim t)
        {
            t.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TblIletisims.Add(t);
            db.SaveChanges();
            return PartialView();
        }
    }
}
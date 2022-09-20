using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using udemy_mvc_cv.Models.Entity;
using udemy_mvc_cv.Repositories;

namespace udemy_mvc_cv.Controllers
{
    public class IletisimController : Controller
    {
        // GET: Iletisim

        GenericRepository<TblIletisim> repo = new GenericRepository<TblIletisim>();

        public ActionResult Index()
        {
            var mesajlar = repo.List();
            return View(mesajlar);
        }
    }
}
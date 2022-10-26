using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcStok.Controllers
{
    public class MusteriController : Controller
    {
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            //var degerler = db.TblMUSTERILER.ToList().ToPagedList(sayfa, 4);//Birinci değerden başla 4 tane getir.
            var degerler = db.TblMUSTERILER.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult MusteriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MusteriEkle(TblMUSTERILER p2)
        {
            if (!ModelState.IsValid)
            {
                return View("MusteriEkle");
            }
            db.TblMUSTERILER.Add(p2);
            db.SaveChanges();
            return View();
        }
        public ActionResult Sil(int id)
        {
            var deger = db.TblMUSTERILER.Find(id);
            db.TblMUSTERILER.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var deger = db.TblMUSTERILER.Find(id);
            return View(deger);
        }
        [HttpPost]
        public ActionResult Update(TblMUSTERILER p)
        {
            var deger = db.TblMUSTERILER.Find(p.MUSTERIID);
            deger.MUSTERISOYAD = p.MUSTERISOYAD;
            deger.MUSTERIAD = p.MUSTERIAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
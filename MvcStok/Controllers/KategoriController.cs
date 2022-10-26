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

    public class KategoriController : Controller
    {
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index(int sayfa = 1)
        {
            var degerler = db.TblKATEGORILER.ToList().ToPagedList(sayfa, 4);//Birinci değerden başla 4 tane getir.
            //var degerler = db.TblKATEGORILER.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniKategori()
        {

            return View();
        }

        [HttpPost]
        public ActionResult YeniKategori(TblKATEGORILER p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.TblKATEGORILER.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult Sil(int id)
        {
            var deger = db.TblKATEGORILER.Find(id);
            db.TblKATEGORILER.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var deger = db.TblKATEGORILER.Find(id);
            return View(deger);
        }
        [HttpPost]
        public ActionResult Update(TblKATEGORILER p)
        {
            var deger = db.TblKATEGORILER.Find(p.KATEGORIID);
            deger.KATEGORIAD = p.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
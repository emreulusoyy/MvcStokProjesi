using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using MvcStok.Models.Entity;
//using PagedList;
//using PagedList.Mvc;

namespace MvcStok.Controllers
{
    public class UrunlerController : Controller
    {
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {

            var degerler = db.TblURUNLER.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> degerler = (from i in db.TblKATEGORILER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();

            ViewBag.dgr = degerler;
            return View();
        }

        [HttpPost]
        public ActionResult UrunEkle(TblURUNLER p3)
        {
          
            var ktg = db.TblKATEGORILER.Where(m => m.KATEGORIID == p3.TblKATEGORILER.KATEGORIID).FirstOrDefault();
            p3.TblKATEGORILER = ktg;
            db.TblURUNLER.Add(p3);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var deger = db.TblURUNLER.Find(id);
            db.TblURUNLER.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            var deger = db.TblURUNLER.Find(id);
            return View(deger);
        }
        [HttpPost]
        public ActionResult Guncelle(TblURUNLER p)

        {
           
            var deger = db.TblURUNLER.Find(p.URUNID);
            deger.MARKA = p.MARKA;
            deger.URUNAD = p.URUNAD;

            deger.URUNKATEGORI = p.URUNKATEGORI;
            deger.FIYAT = p.FIYAT;
            deger.STOK = p.STOK;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
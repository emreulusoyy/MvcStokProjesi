using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
namespace MvcStok.Controllers
{
    public class SatısController : Controller
    {
        MvcDbStokEntities db = new MvcDbStokEntities(); 
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult YeniSatıs()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(TblSATISLAR p)
        {
            db.TblSATISLAR.Add(p);
            db.SaveChanges();
            return View("Index");
        }
      
    }
}
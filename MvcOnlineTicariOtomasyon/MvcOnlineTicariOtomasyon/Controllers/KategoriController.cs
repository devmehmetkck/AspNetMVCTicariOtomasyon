using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        Context c=new Context();
        
        public ActionResult Index()
        {
            var degerler = c.Kategoris.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KategoriEkle(Kategori kategori)
        {
            c.Kategoris.Add(kategori);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public  ActionResult KategoriGetir(int id)
        {
            var ktgr=c.Kategoris.Find(id);
            return View("KategoriGetir", ktgr);
        }
        public ActionResult KategoriGuncelle(Kategori kategori)
        {
            var ktgr = c.Kategoris.Find(kategori.KategoriID);
            ktgr.KategoriAd = kategori.KategoriAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
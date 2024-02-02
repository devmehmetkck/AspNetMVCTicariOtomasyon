using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;
using PagedList;
using PagedList.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class DepartmanController : Controller
    {
        
        Context c=new Context();
        public ActionResult Index()
        {
            var degerler=c.Departmans.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();

        }

        [HttpPost]
        public ActionResult DepartmanEkle(Departman departman)
        {
            c.Departmans.Add(departman);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanSil(int id)
        {
            var deger=c.Departmans.Find(id);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanGetir(int id)
        {
            var deger = c.Departmans.Find(id);
            return View("DepartmanGetir",deger);

        }
        public ActionResult DepartmanGuncelle(Departman departman)
        {
            var deger = c.Departmans.Find(departman.DepartmanID);
            deger.DepartmanAd=departman.DepartmanAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult DepartmanDetay(int id)
        {
            var degerler = c.Personels.Where(m=>m.Departman.DepartmanID==id).ToList();
            var dpt = c.Departmans.Where(x => x.DepartmanID == id).Select(k => k.DepartmanAd).FirstOrDefault();
            int adet=c.SatisHarekets.ToList().Count();
            ViewBag.satisadet = adet;
            ViewBag.d = dpt;
            return View(degerler);
        }

        public ActionResult DepartmanPersonelSatis(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.Personel.PersonelID == id).ToList();
            var personel = c.Personels.Where(m => m.PersonelID == id).Select(p => p.PersonelAd + " " + p.PersonelSoyad).FirstOrDefault();
            ViewBag.dper = personel;
            return View(degerler);
        }
       
    }
}
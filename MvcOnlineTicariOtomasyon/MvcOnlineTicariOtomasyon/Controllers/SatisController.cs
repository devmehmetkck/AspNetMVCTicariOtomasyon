using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        Context c=new Context();
        public ActionResult Index()
        {
            var degerler = c.SatisHarekets.ToList();
            
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            List<SelectListItem> cari=(from x in c.Carilers.ToList()
                                       select new SelectListItem
                                       {
                                           Text=x.CariAd+" "+x.CariSoyad,
                                           Value=x.CariID.ToString()
                                       }).ToList();
            List<SelectListItem> personel=(from x in c.Personels.Where(m=>m.Departman.DepartmanID==1).ToList()
                                       select new SelectListItem
                                       {
                                           Text=x.PersonelAd+" "+x.PersonelSoyad,
                                           Value=x.PersonelID.ToString()
                                       }).ToList();
            List<SelectListItem> urun=(from x in c.Uruns.ToList()
                                       select new SelectListItem
                                       {
                                           Text=x.UrunAd,
                                           Value=x.UrunID.ToString()
                                       }).ToList();
            
            ViewBag.cari = cari;
            ViewBag.personel = personel;
            ViewBag.urun = urun;
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(SatisHareket satis)
        {
            var cari = c.Carilers.Where(m => m.CariID == satis.Cari.CariID).FirstOrDefault();
            var personel = c.Personels.Where(m => m.PersonelID == satis.Personel.PersonelID).FirstOrDefault();
            var urun = c.Uruns.Where(m => m.UrunID == satis.Urun.UrunID).FirstOrDefault();
            satis.Cari = cari;
            satis.Personel = personel;
            satis.Urun = urun;
            satis.Fiyat = urun.SatisFiyati;
            satis.ToplamTutar = urun.SatisFiyati * satis.Adet;
            c.SatisHarekets.Add(satis);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Arama(string nesne = "a")
        {
            var degerler = c.SatisHarekets.Where(x => x.Urun.UrunAd.Contains(nesne)).ToList();
            return View("Index", degerler);
        }
        
        

    }
}
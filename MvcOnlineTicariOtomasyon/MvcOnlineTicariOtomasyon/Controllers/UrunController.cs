using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Uruns.Where(m => m.Durum == true).ToList();
            for (int i = 0; i < degerler.Count; i++)
            {
                int adet= KacAdet(degerler[i].UrunID);
                degerler[i].SatilmaAdet= adet;
                c.SaveChanges();
            }
            return View(degerler);
        }
        public ActionResult SatistaOlmayanlar()
        {
            var degerler = c.Uruns.Where(m => m.Durum == false).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> list = (from x in c.Kategoris.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.KategoriAd,
                                             Value = x.KategoriID.ToString()
                                         }).ToList();
            ViewBag.drop1 = list;
            return View();
        }

        [HttpPost]
        public ActionResult YeniUrun(Urun yeniUrun)
        {
            var ktgr = c.Kategoris.Where(m => m.KategoriID == yeniUrun.Kategori.KategoriID).FirstOrDefault();
            if (yeniUrun.Stok > 0)
            {
                yeniUrun.Durum = true;
                yeniUrun.Kategori = ktgr;
                c.Uruns.Add(yeniUrun);
                c.SaveChanges();
                return RedirectToAction("Index");

            }
            else
                return View();
        }

        public ActionResult UrunGetir(int id)
        {
            var urun = c.Uruns.Find(id);
            List<SelectListItem> deger = (from x in c.Kategoris.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.KategoriAd,
                                              Value = x.KategoriID.ToString()
                                          }).ToList();
            ViewBag.deger = deger;
            return View("UrunGetir", urun);
        }

        public ActionResult UrunGuncelle(Urun urun)
        {
            var gelen = c.Uruns.Find(urun.UrunID);
            gelen.UrunAd = urun.UrunAd;
            gelen.Marka = urun.Marka;
            gelen.Stok = urun.Stok;
            gelen.AlisFiyati = urun.AlisFiyati;
            gelen.SatisFiyati = urun.SatisFiyati;
            var ktgr = c.Kategoris.Where(m => m.KategoriID == urun.Kategori.KategoriID).FirstOrDefault();
            gelen.Kategori = ktgr;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(int id)
        {
            var urun = c.Uruns.Find(id);
            urun.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatisaEkle(int id)
        {
            var urun = c.Uruns.Find(id);
            urun.Stok = (Byte)1;
            urun.Durum = true;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        int KacAdet(int id)
        {
            int sayi=c.SatisHarekets.Where(x=>x.Urun.UrunID==id).ToList().Count();
            return sayi;
        }

        public ActionResult UrunListesi()
        {
            var degerler = c.Uruns.ToList();
            return View(degerler);
        }

    }
}
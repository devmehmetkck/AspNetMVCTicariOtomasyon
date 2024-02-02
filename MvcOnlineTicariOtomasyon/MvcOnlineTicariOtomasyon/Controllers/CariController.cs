using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        Context c=new Context();
        public ActionResult Index()
        {
            var degerler=c.Carilers.Where(x=>x.Durum).ToList();
            for (int i = 0; i < degerler.Count; i++)
            {
                int adet = KacAdet(degerler[i].CariID);
                degerler[i].AlimAdet = adet;
                c.SaveChanges();
            }
            return View(degerler);
        }

        public ActionResult CariSatis(int id)
        {
            var degerler=c.SatisHarekets.Where(x=>x.Cari.CariID==id).ToList();
            var cari = c.Carilers.Where(a => a.CariID == id).Select(p => p.CariAd + " " + p.CariSoyad).FirstOrDefault();
            ViewBag.dcari = cari;
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniCari()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniCari(Cari cari)
        {
            c.Carilers.Add(cari);
            cari.Durum = true;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        int KacAdet(int id)
        {
            int sayi = c.SatisHarekets.Where(m => m.Cari.CariID == id).ToList().Count();
            return sayi;
        }


    }
}
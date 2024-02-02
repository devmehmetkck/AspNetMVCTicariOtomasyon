using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class SatisHareket
    {
        [Key]
        public int SatisID { get; set; }

        //Ürün
        //Cari
        //Personel
        public DateTime Tarih { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
        public decimal ToplamTutar { get; set; }
        public virtual Urun Urun { get; set; }
        public virtual Cari Cari { get; set; }
        public virtual Personel Personel { get; set; }
    }
}
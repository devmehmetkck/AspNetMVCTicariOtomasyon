using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Urun
    {
        [Key]
        public int UrunID { get; set; }

        [Column(TypeName="VarChar")]
        [StringLength(30)]
        public string UrunAd { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string Marka { get; set; }
        public short Stok { get; set; }
        public decimal AlisFiyati { get; set; }
        public decimal SatisFiyati { get; set; }
        public bool Durum { get; set; }
        public int SatilmaAdet {  get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string Gorsel { get; set; }
        public virtual Kategori Kategori { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}
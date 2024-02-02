using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Cari
    {
        [Key]
        public int CariID { get; set; }


        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string CariAd { get; set;}

        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string CariSoyad { get; set;}

        [Column(TypeName = "VarChar")]
        [StringLength(13)]
        public string Sehir { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(50)]
        public string Mail { get; set; }
        public bool Durum { get; set; }
        public int AlimAdet { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}
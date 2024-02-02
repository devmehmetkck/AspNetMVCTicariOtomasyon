using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Personel
    {
        [Key]
        public int PersonelID { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter olmalıdır")]
        [Required(ErrorMessage = "Ad Alanı Boş Bırakılamaz")]
        public string PersonelAd { get; set; }


        [Column(TypeName = "VarChar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter olmalıdır")]
        [Required(ErrorMessage = "Soyad Alanı Boş Bırakılamaz")]
        public string PersonelSoyad { get; set; }


        public bool Durum { get; set; }
        public int SatisAdet { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }

        public virtual Departman Departman { get; set; }
    }
}
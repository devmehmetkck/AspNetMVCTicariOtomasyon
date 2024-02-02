using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Kategori
    {
        [Key]
        public int KategoriID { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public virtual string KategoriAd { get; set; }
        public virtual ICollection<Urun> Uruns { get; set; }
    }
}
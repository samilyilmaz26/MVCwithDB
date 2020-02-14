using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCwithDB.Entities
{
    public class Personel
    {
        [Key]
        public int PersonelId { get; set; }
        public string  PersonelAd { get; set; }
        public string  PersonelSoyad { get; set; }
        public int RolId { get; set; }
        [ForeignKey("RolId")]
        public Roles  Roles { get; set; }
    }
}

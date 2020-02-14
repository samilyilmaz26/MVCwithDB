using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCwithDB.Entities
{
    public class Roles
    {
        [Key]
        public int RoleId { get; set; }
        public string  RoleAd { get; set; }
        public ICollection< Personel> Personels { get; set; }
    }
}

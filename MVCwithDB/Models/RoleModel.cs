using MVCwithDB.DTOs;
using MVCwithDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCwithDB.Models
{
    public class RoleModel
    {
        public List<RolesDTO> rlist { get; set; }
        public Roles  Roles { get; set; }
    }
}

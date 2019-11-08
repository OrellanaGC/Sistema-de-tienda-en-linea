using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using tiendaOnline.Areas.Identity.Data;

namespace tiendaOnline.Models
{
    public class Direccion
    {
        public int DireccionID { get; set; }
        
        public string nombre_direccion { get; set; }

        public int MunicipioID { get; set; }
        public Municipio Municipio { get; set; }

        //relacion para user
        public string tiendaOnlineUserID { get; set; }
        public tiendaOnlineUser tiendaOnlineUser { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using tiendaOnline.Areas.Identity.Data;

namespace tiendaOnline.Models
{
    public class Orden
    {
        public List<LineaDeOrden> LineasDeOrden { get; set; } 
        public int OrdenID { get; set; }

        [Required]
        [Display(Name ="Fecha de Orden")]
        public DateTime fechaOrden { get; set; }

        [Required]
        [Display(Name = "Total de Orden")]
        public double total { get; set; }

        [Required]
        [Display(Name = "Estado de Orden")]
        public Boolean estadoDeOrden { get; set; }

        //Relacion con usuario
        public tiendaOnlineUser tiendaOnlineUser { get; set; }
        public string tiendaOnlineUserID { get; set; }

        //Relacion con MetodoEnvio
        public MetodoEnvio metodoEnvio { get; set; }
        public int metodoEnvioID { get; set; }

        //Relacion con Cupon
        public Cupon cupon { get; set; }
        public int? cuponID { get; set; }

        public Orden()
        {
            estadoDeOrden = true;
            fechaOrden = DateTime.Now;

        }
    }
}

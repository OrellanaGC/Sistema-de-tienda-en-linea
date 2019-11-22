using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using tiendaOnline.Models; //importar models para traer a carrito 

namespace tiendaOnline.Areas.Identity.Data
{
    //lista para sexo
    public enum Sexo
    {
        [Display(Name = "Masculino")] Masculino,
        [Display(Name = "Femenino")] Femenino

    }
    
    public class tiendaOnlineUser : IdentityUser
    {
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public DateTime fecheDeNacimiento { get; set; }
        public Sexo sexo { get; set; }


        //carrito One-to-One con Carrito        
        public Carrito Carrito { get; set; }

        //Relacion oneToOne con DetalleVendedor
        public DetalleVendedor detalleVendedor { get; set; }




    }
}

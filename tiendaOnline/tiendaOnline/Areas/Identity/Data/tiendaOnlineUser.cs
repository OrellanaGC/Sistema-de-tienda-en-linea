using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using tiendaOnline.Models; //importar models para traer a carrito 

namespace tiendaOnline.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the tiendaOnlineUser class
    public class tiendaOnlineUser : IdentityUser
    {
        public string Nombres { get; set; }
        public string Apellidos;


        //carrito One-to-One, el carrito se crea junto con el usuario
       public int CarritoID { get; set; } 
       public Carrito Carrito { get; set; }

        //relacion tarjeta 
        public int TipoDePagoID { get; set; }
        public TipoDePago TipoDePago { get; set; }



        //Metodos para el usuario
        //get y set para atributos
        public string apellidos
        {
            get => Apellidos;
            set
            {
                Apellidos = value;
            }
        }


    

    }
}

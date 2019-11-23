using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tiendaOnline.Models
{
    public class Sucursal
    {
        public int SucursalID { get; set; }

        public string nombreSucursal;
        public string horarioDeAtencion;
        

        public Sucursal()
        {
            nombreSucursal ="Sucursal El Triunfo";
            horarioDeAtencion= "Nuestro horario de atención al cliente es de lunes a viernes, de 8 de la mañana a 5 de la tarde.";
        }

    }
}

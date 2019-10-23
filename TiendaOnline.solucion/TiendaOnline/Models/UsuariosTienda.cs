using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaOnline.Models
{
    public class UsuariosTienda : IdentityUser
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
    }
}

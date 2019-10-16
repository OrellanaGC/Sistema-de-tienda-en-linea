using System;
using System.Collections.Generic;

namespace TiendaOnline.Models
{
    public partial class Municipio
    {
        public Municipio()
        {
            Departamento = new HashSet<Departamento>();
        }

        public int IdMunicipio { get; set; }
        public string NombreMunicipio { get; set; }

        public ICollection<Departamento> Departamento { get; set; }
    }
}

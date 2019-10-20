using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TiendaOnline.Models
{
    public partial class Municipio
    {
        public Municipio()
        {
            Departamento = new HashSet<Departamento>();
        }
        [Key]
        public int IdMunicipio { get; set; }
        public string NombreMunicipio { get; set; }

        public ICollection<Departamento> Departamento { get; set; }
    }
}

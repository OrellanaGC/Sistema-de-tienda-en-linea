using System;
using System.Collections.Generic;

namespace TiendaOnline.Models
{
    public partial class Departamento
    {
        public Departamento()
        {
            Direccion = new HashSet<Direccion>();
        }

        public int IdDepartamento { get; set; }
        public int IdMunicipio { get; set; }
        public string NombreDepartamento { get; set; }

        public Municipio IdMunicipioNavigation { get; set; }
        public ICollection<Direccion> Direccion { get; set; }
    }
}

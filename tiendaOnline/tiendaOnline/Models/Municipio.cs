using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tiendaOnline.Models
{
    public class Municipio
    {

        public int MunicipioID { get; set; }
        [Required(ErrorMessage = "Ingresar nombre del Municipio")]
        public string nombreMunicipio { get; set; }
        //Relacion con Departamento
        public Departamento Departamento { get; set; }
        public int DepartamentoID { get; set; }

    }

}

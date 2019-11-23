using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tiendaOnline.Models
{
    public class Empresa
    {
        public int EmpresaID { get; set; }

        
        public string nombreEmpresa { get; set; }

        public string correoComercial { get; set; }

        public Empresa()
        {
            nombreEmpresa="iBuy Corporation";
            correoComercial = "iBuy.newstoreonline@gmail.com";
        }
    }
}

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
        [Required(ErrorMessage ="Ingresar nombre del Municipio")]
        public string nombreMunicipio { get; set; }  
        [Required(ErrorMessage ="Ingresar Departamento")]
        public Departamentos Departamento { get; set; }
    }

    //Lista de departamentos
    public enum Departamentos
    {
        [Display(Name ="Ahuachapán")]      Ahuachapan,
        [Display(Name = "Cabañas")]        Cabanas,
        [Display(Name = "Chalatenago")]    Chalatenango,
        [Display(Name = "Cuscatlán")]      Cuscatlan,
        [Display(Name = "La Libertad")]    LaLibertad,
        [Display(Name = "La Paz")]         LaPaz,
        [Display(Name = "La Unión")]       LaUnion,
        [Display(Name = "Morazan")]        Morazan,
        [Display(Name = "Santa Ana")]      SantaAna,
        [Display(Name = "San Salvador")]   SanSalvador,
        [Display(Name = "San Miguel")]     SanMiguel,
        [Display(Name = "San Vicente")]    SanVicente,
        [Display(Name = "Sonsonate")]      Sonsonate,
        [Display(Name = "Usulután")]       Usulutan


    }
}

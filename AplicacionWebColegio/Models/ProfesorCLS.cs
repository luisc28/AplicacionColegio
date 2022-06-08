using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AplicacionWebColegio.Models
{
    public class ProfesorCLS
    {
        [Display(Name ="ID Profesor")]
        public int iidprofesores { get; set; }
        [Display(Name = "Nombre Profesor")]
        public string nombre { get; set; }
        [Display(Name = "Apellido Profesor")]
        public string apellido { get; set; }
        [Display(Name = "Materia")]
        public string materia { get; set; }
        [Display(Name = "Email")]
        public string email { get; set; }
        public int bhabilitado { get; set; }
    }
}
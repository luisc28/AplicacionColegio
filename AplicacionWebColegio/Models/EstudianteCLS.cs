using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AplicacionWebColegio.Models
{
    public class EstudianteCLS
    {
        [Display(Name ="ID Estudiante")]
        public int iidestudiante { get; set; }
        [Display(Name = "Nombre Estudiante")]
        public string nombre { get; set; }
        [Display(Name = "Apellido Estudiante")]
        public string apellido { get; set; }
        [Display(Name = "Curso")]
        public string curso { get; set; }
        [Display(Name = "Email")]
        public string email { get; set; }
        public int bhabilitado { get; set; }

    }
}
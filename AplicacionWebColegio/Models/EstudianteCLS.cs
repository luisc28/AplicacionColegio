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
        public int Iidestudiante { get; set; }
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }
        [Display(Name = "Curso")]
        public int Curso { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        public int Bhabilitado { get; set; }
    }
}
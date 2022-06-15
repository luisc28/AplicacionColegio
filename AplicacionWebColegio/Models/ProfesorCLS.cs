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
        [Required]
        [StringLength(100,ErrorMessage = "Longitud maxima 100")]
        public string nombre { get; set; }
        [Display(Name = "Apellido Profesor")]
        [Required]
        [StringLength(100, ErrorMessage = "Longitud maxima 100")]
        public string apellido { get; set; }
        [Display(Name = "Sexo")]
        [Required]
        public int iidsexo { get; set; }
        [Display(Name = "Materia")]
        [Required]
        [StringLength(100, ErrorMessage = "Longitud maxima 100")]
        public string materia { get; set; }
        [Display(Name = "Email")]
        [Required]
        [StringLength(100, ErrorMessage = "Longitud maxima 100")]
        [EmailAddress(ErrorMessage = "Ingrese un email valido")]
        public string email { get; set; }
        public int bhabilitado { get; set; }
    }
}
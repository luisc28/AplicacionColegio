//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AplicacionWebColegio.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Estudiantes
    {
        public int IIDESTUDIANTES { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO { get; set; }
        public string CURSO { get; set; }
        public string EMAIL { get; set; }
        public Nullable<int> BHABILITADO { get; set; }
        public Nullable<int> IIDSEXO { get; set; }
    
        public virtual Sexo Sexo { get; set; }
    }
}

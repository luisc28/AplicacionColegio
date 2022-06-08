using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AplicacionWebColegio.Models;

namespace AplicacionWebColegio.Controllers
{
    public class ProfesoresController : Controller
    {
        // GET: Profesores
        public ActionResult Index()
        {
            List<ProfesorCLS> listaProfesor = null;
            using (var bd= new BDCOLEGIOBOTOGAEntities())
            {
                listaProfesor = (from profesor in bd.Profesores
                                 where profesor.BHABILITADO == 1
                                 select new ProfesorCLS
                                 {
                                     iidprofesores = profesor.IIDPROFESORES,
                                     nombre = profesor.NOMBRE,
                                     apellido = profesor.APELLIDO,
                                     materia = profesor.MATERIA,
                                     email = profesor.EMAIL
                                 }).ToList();
            }
            return View(listaProfesor);
        }
    }
}
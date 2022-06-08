using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AplicacionWebColegio.Models;

namespace AplicacionWebColegio.Controllers
{
    public class EstudiantesController : Controller
    {
        // GET: Estudiantes
        public ActionResult Index()
        {
            List<EstudianteCLS> listaEstudiante = null;
            using (var bd = new BDCOLEGIOBOTOGAEntities())
            {
                listaEstudiante = (from estudiante in bd.Estudiantes
                                  where estudiante.BHABILITADO == 1
                                  select new EstudianteCLS
                                  {
                                      iidestudiante = estudiante.IIDESTUDIANTES,
                                      nombre = estudiante.NOMBRE,
                                      apellido = estudiante.APELLIDO,
                                      curso = estudiante.CURSO,
                                      email = estudiante.EMAIL
                                  }).ToList();
            }
            return View(listaEstudiante);
        }
    }
}
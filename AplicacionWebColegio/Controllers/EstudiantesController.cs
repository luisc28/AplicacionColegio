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
                                      Iidestudiante = estudiante.IIDESTUDIANTES,
                                      Nombre = estudiante.NOMBRE,
                                      Apellido = estudiante.APELLIDO,
                                      Curso = estudiante.CURSO,
                                      Email = estudiante.EMAIL
                                  }).ToList();
            }
            return View(listaEstudiante);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(EstudianteCLS estudianteCLS)
        {
            if (!ModelState.IsValid)
            {
                return View (estudianteCLS);
            }
            using (var bd=new BDCOLEGIOBOTOGAEntities())
            {
                Estudiantes estudiantes = new Estudiantes();
                estudiantes.IIDESTUDIANTES = estudianteCLS.Iidestudiante;
                estudiantes.NOMBRE = estudianteCLS.Nombre;
                estudiantes.APELLIDO = estudianteCLS.Apellido;
                estudiantes.CURSO = estudianteCLS.Curso;
                estudiantes.EMAIL = estudianteCLS.Email;
                bd.Estudiantes.Add(estudiantes);
                bd.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
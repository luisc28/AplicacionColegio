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
                listaProfesor = (from profesores in bd.Profesores
                                 where profesores.BHABILITADO == 1
                                 select new ProfesorCLS
                                 {
                                     iidprofesores = profesores.IIDPROFESORES,
                                     nombre = profesores.NOMBRE,
                                     apellido = profesores.APELLIDO,
                                     materia = profesores.MATERIA,
                                     email = profesores.EMAIL
                                 }).ToList();
            }
            return View(listaProfesor);
        }
        [HttpGet]
        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(ProfesorCLS oProfesorCLS)
        {
            if (!ModelState.IsValid)
            {
                return View(oProfesorCLS);
            }
            using (var bd = new BDCOLEGIOBOTOGAEntities())
            {
                Profesores oProfesores = new Profesores();
                oProfesores.NOMBRE = oProfesorCLS.nombre;
                oProfesores.APELLIDO = oProfesorCLS.apellido;
                oProfesores.MATERIA = oProfesorCLS.materia;
                oProfesores.EMAIL = oProfesorCLS.email;
                oProfesores.BHABILITADO = 1;
                bd.Profesores.Add(oProfesores);
                bd.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
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
            using (var bd= new BDCOLEGIOBOTOGAEntities2())
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
        //AGREGAR UN ComboBox para el seleccionar Sexo
        List<SelectListItem> listaSexo;
        private void llenarSexo()
        {
            using(var bd=new BDCOLEGIOBOTOGAEntities2())
            {
                listaSexo = (from sexo in bd.Sexo
                             where sexo.BHABILITADO == 1
                             select new SelectListItem
                             {
                                 Text = sexo.NOMBRE,
                                 Value = sexo.IIDSEXO.ToString()
                             }).ToList();
                listaSexo.Insert(0, new SelectListItem { Text = "--Seleccione--", Value = "" });
            }
        }

        [HttpGet]
        public ActionResult Agregar()
        {
            llenarSexo();
            ViewBag.lista = listaSexo;
            return View();
        }
        [HttpPost]
        public ActionResult Agregar(ProfesorCLS oProfesorCLS)
        {
            if (!ModelState.IsValid)
            {
                llenarSexo();
                ViewBag.lista = listaSexo;
                return View(oProfesorCLS);
            }
            using (var bd = new BDCOLEGIOBOTOGAEntities2())
            {
                Profesores oProfesores = new Profesores();
                oProfesores.NOMBRE = oProfesorCLS.nombre;
                oProfesores.APELLIDO = oProfesorCLS.apellido;
                oProfesores.MATERIA = oProfesorCLS.materia;
                oProfesores.EMAIL = oProfesorCLS.email;
                oProfesores.IIDSEXO = oProfesorCLS.iidsexo;
                oProfesores.BHABILITADO = 1;
                bd.Profesores.Add(oProfesores);
                bd.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Editar(int id)
        {
            ProfesorCLS oProfesorCLS = new ProfesorCLS();
            using (var bd = new BDCOLEGIOBOTOGAEntities2())
            {
                llenarSexo();
                ViewBag.lista = listaSexo;
                Profesores oProfesores = bd.Profesores.Where(p => p.IIDPROFESORES.Equals(id)).First();
                oProfesorCLS.iidprofesores = oProfesores.IIDPROFESORES;
                oProfesorCLS.nombre = oProfesores.NOMBRE;
                oProfesorCLS.apellido = oProfesores.APELLIDO;
                oProfesorCLS.materia = oProfesores.MATERIA;
                oProfesorCLS.email = oProfesores.EMAIL;
                oProfesorCLS.iidsexo = (int)oProfesores.IIDSEXO;
            }
            return View(oProfesorCLS);
        }
        [HttpPost]
        public ActionResult Editar(ProfesorCLS oProfesorCLS)
        {
            int idProfesor = oProfesorCLS.iidprofesores;
            if (!ModelState.IsValid)
            {
                return View(oProfesorCLS);
            }
            using (var bd=new BDCOLEGIOBOTOGAEntities2())
            {

                Profesores oProfesor = bd.Profesores.Where(p => p.IIDPROFESORES.Equals(idProfesor)).First();
                oProfesor.NOMBRE = oProfesorCLS.nombre;
                oProfesor.APELLIDO = oProfesorCLS.apellido;
                oProfesor.MATERIA = oProfesorCLS.materia;
                oProfesor.EMAIL = oProfesorCLS.email;
                oProfesor.IIDSEXO = oProfesorCLS.iidsexo;
                bd.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Eliminar(int id)
        {
            using (var bd=new BDCOLEGIOBOTOGAEntities2())
            {
                Profesores oProfesor = bd.Profesores.Where(p => p.IIDPROFESORES.Equals(id)).First();
                oProfesor.BHABILITADO = 0;
                bd.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
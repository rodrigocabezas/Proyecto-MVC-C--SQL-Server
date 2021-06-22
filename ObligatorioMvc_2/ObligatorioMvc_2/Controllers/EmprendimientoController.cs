using ObligatorioMvc_2.Contexto;
using ObligatorioMvc_2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ObligatorioMvc_2.Controllers
{
    public class EmprendimientoController:Controller
    {
        private MiContexto bd = new MiContexto();

        public PartialViewResult FiltroInferiorOIgual()
        {
            var usu = bd.Financiadores.Where(u => u.NombreUsuario == User.Identity.Name).FirstOrDefault();
            var emp = bd.Emprendimientos.Where(e => e.Costo <= usu.MontoMaximo);
            return PartialView("View",emp);
        }
        public PartialViewResult FiltroInferiorOIgualNoFinanciado()
        {
            var usu = bd.Financiadores.Where(u => u.NombreUsuario == User.Identity.Name).FirstOrDefault();
            var emp = bd.Emprendimientos.Where(e => e.Costo <= usu.MontoMaximo && e.Financiado==0);
            return PartialView("View", emp);
        }
        public PartialViewResult FiltroOrdenarPorPuntaje()
        {
            var emp = bd.Emprendimientos.OrderByDescending(e => e.PuntajeFinal).OrderBy(e=>e.PuntajeFinal);
            return PartialView("View",emp);
        }
        public PartialViewResult FiltroOrdenarPorPuntajeNoFinanciado()
        {
            var emp = bd.Emprendimientos.OrderByDescending(e => e.PuntajeFinal).OrderBy(e => e.PuntajeFinal).Where(e=>e.Financiado==0);
            return PartialView("View", emp);
        }
        public PartialViewResult FiltroRangoCosto(int? Valor1, int? Valor2)
        {
            var emp2 = bd.Emprendimientos;
            if (Valor1 != null || Valor2 != null)
            {
                var emp = bd.Emprendimientos.Where(e => e.Costo >= Valor1 && e.Costo <= Valor2);
                return PartialView("View", emp);
            }
            else
            {
                return PartialView("View", emp2);
            }
        }
        public PartialViewResult FiltroRangoCostoNoFinanciado(int? Valor1, int? Valor2)
        {
            var emp2 = bd.Emprendimientos;
            if (Valor1 != null || Valor2 !=null)
            {
                var emp = bd.Emprendimientos.Where(e => e.Costo >= Valor1 && e.Costo <= Valor2 && e.Financiado == 0);
                return PartialView("View", emp);
            }
            else
            {
                return PartialView("View", emp2);
            }
        }
        public PartialViewResult FiltroDuracion(int? Duracion)
        {
            var emp2 = bd.Emprendimientos;
            if (Duracion != null)
            {
                var emp = bd.Emprendimientos.Where(e => e.Dias < Duracion);
                return PartialView("View", emp);
            }
            else
            {
                return PartialView("View", emp2);
            }
        }
        public PartialViewResult FiltroDuracionNoFinanciado(int? Duracion)
        {
            var emp2 = bd.Emprendimientos;
            if (Duracion != null)
            {
                var emp = bd.Emprendimientos.Where(e => e.Dias < Duracion);
                return PartialView("View", emp);
            }
            else
            {
                return PartialView("View", emp2);
            }
        }
        public ActionResult VerDetalle(int Id)
        {
            var emp = bd.Emprendimientos.Where(u => u.Id == Id).ToList();
            return View(emp);
        }
        public ActionResult ListarEmprendimientos()
        {

               return View( bd.Emprendimientos.ToList());
                ////var listaEmp = bd.Emprendimientos;
                //return View(bd.Emprendimientos.ToList().AsEnumerable());
        }
        public ActionResult ListarEmprendimientosNoFinanciados()
        {
            return View(bd.Emprendimientos.Where(e=>e.Financiado==0));
        }

        public ActionResult MisEmprendimientos()
        {
            var usu = bd.Financiadores.Where(u => u.NombreUsuario == User.Identity.Name).FirstOrDefault();
            var emp = bd.Emprendimientos.Where(e => e.IdFinanciador == usu.Id).ToList();
            return View(emp);
        }
        public ActionResult Financiar(int Id)
        {
            var usu = bd.Financiadores.Where(u => u.NombreUsuario == User.Identity.Name).FirstOrDefault();
            var emp = bd.Emprendimientos.FirstOrDefault(e => e.Id == Id);
            emp.IdFinanciador = usu.Id;
            emp.Financiado = 1;
            bd.SaveChanges();
            return RedirectToAction("MisEmprendimientos");
        }
        public ActionResult CargaArchivo()// Retorna la vista(el input file)
        {
            return View();
        }
        public ActionResult SubidaArchivo()
        {

            var resultado = "";
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];//Obtengo el archivo

                if (file != null && file.ContentLength > 0)//Pregutno si es distinto de null y si es mayor que cero (los bytes)
                {
                    StreamReader reader = new StreamReader(file.InputStream);//Le paso el flujo de datos
                    do
                    {
                        string textLine = reader.ReadLine();//Devuelve la linea hasta que llega al salto de linea
                        var arregloConDatos = textLine.Split('#'); //Esto va para el Obligatorio //Nosotros va con #
                        var nuevoEmprendimiento = new Emprendimiento
                        {
                            Id = Convert.ToInt32(arregloConDatos[0]), //Poner nuestos datos de emprendimiento
                            Titulo = Convert.ToString(arregloConDatos[1]),
                            Costo = Convert.ToInt32(arregloConDatos[2]),
                            Dias = Convert.ToInt32(arregloConDatos[3]),
                            PuntajeFinal = Convert.ToInt32(arregloConDatos[4]),
                            Descripcion = Convert.ToString(arregloConDatos[5]),
                            Financiado = 0,
                            IdFinanciador=0

                        };
                        bd.Emprendimientos.Add(nuevoEmprendimiento);//Agrega en Facturas nosotro agregamos emprendiemirnotos

                        resultado += textLine + "<br>";
                    } while (reader.Peek() != -1);//Para ver que no llega al final del archivo
                    reader.Close();//Cierra el reader
                    bd.SaveChanges();//Guarda en la base
                    return View("CargaCorrecta");// Retornamos las vista
                }
            }
            return View("NoSePudoCargar"); //Arreglar esto

        }
    }
}
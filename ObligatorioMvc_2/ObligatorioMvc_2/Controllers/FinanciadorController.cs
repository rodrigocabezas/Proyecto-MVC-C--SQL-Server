using ObligatorioMvc_2.Contexto;
using ObligatorioMvc_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;

namespace ObligatorioMvc_2.Controllers
{
    public class FinanciadorController : Controller
    {
        private MiContexto bd = new MiContexto();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Financiador f)
        {

            var passEncrypt = f.Contraseña;
            var u = bd.Financiadores.FirstOrDefault(usu => usu.Email.Equals(f.Email) && usu.Contraseña.Equals(passEncrypt));
            //var u =  bd.Financiadores.Where.Select(usu => usu.Email.Equals(f.Email) && usu.Contraseña.Equals(Crypto.SHA256(f.Contraseña)));

            if (u != null)
            {
                FormsAuthentication.SetAuthCookie(u.NombreUsuario, false);
                Session["usu"] = u;
                return RedirectToAction("Index", "Home");
            }

            else
            {
                ModelState.AddModelError("", "Usuario y/o clave incorrectos");
                return View();
            }
        }
        [Authorize]
        [HttpGet]
        public ActionResult CerrarSesion()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult Registrar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registrar(Financiador f)
        {
            if (ModelState.IsValid)
            {
                var NombreYaExiste = bd.Financiadores.FirstOrDefault(nu => nu.NombreUsuario.Equals(f.NombreUsuario));
                if (NombreYaExiste != null)
                {
                    ModelState.AddModelError(string.Empty, "Nombre de Usuario ya existe");
                    return View(f);
                }
                else
                {
                    bd.Financiadores.Add(f);
                    bd.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(f);
        }

    }
}
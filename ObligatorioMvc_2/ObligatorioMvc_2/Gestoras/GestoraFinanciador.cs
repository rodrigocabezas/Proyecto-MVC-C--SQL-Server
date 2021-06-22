using ObligatorioMvc_2.Contexto;
using ObligatorioMvc_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace ObligatorioMvc_2.Gestoras
{
    public class GestoraFinanciador
    {
        private MiContexto bd = new MiContexto();

        //public Financiador ValidarCredencialesUsuario(Financiador u)
        //{
        //    var rol = bd.Financiadores.Where(usu => usu.NombreUsuario.Equals(u.NombreUsuario) && usu.Contraseña.Equals(Crypto.SHA256(u.Contraseña)));
        //    return rol;
        //    //return Usuarios.Count(usu => usu.NombreUsuario.Equals(u.NombreUsuario) && usu.Clave.Equals(u.Clave)) == 1;
        //}
    }
}
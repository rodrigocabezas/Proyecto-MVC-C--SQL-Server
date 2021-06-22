using ObligatorioMvc_2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ObligatorioMvc_2.Contexto
{
    public class MiContexto:DbContext
    {

        public MiContexto()
            :base("conn")
        {

        }
        public DbSet<Emprendimiento> Emprendimientos { get; set; }
        public DbSet<Financiador> Financiadores { get; set; }
    }
}
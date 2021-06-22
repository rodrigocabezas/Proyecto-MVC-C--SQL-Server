using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ObligatorioMvc_2.Models
{
    public class Emprendimiento
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Titulo { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(500)]
        public string Descripcion { get; set; }

        public int Costo { get; set; }
        public int Dias { get; set; }
        public int PuntajeFinal { get; set; }

        public int Financiado { get; set; }

        [ForeignKey("IdFinanciador")]
        public virtual Financiador Financiador { get; set; }
        public int IdFinanciador { get; set; }
    }
}
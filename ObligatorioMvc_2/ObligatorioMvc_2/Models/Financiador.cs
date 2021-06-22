using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ObligatorioMvc_2.Models
{
    public class Financiador
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(50)]
        [Required(ErrorMessage = "Debe ingresar el NombreUsuario")]
        public string NombreUsuario { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        [Required(ErrorMessage = "Debe ingresar el Email")]
        public string Email { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(50)]
        [Required(ErrorMessage = "Debe ingresar el Contraseña")]
        [DataType(DataType.Password)]
        public string Contraseña { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(50)]
        [Required(ErrorMessage = "Debe ingresar el Nombre de Organizacion")]
        public string NombreOrganizacion { get; set; }

        [Required(ErrorMessage = "Debe ingresar el Monto Maximo")]
        public decimal MontoMaximo { get; set; }

        public virtual ICollection<Emprendimiento> Emprendimientos { get; set; }

    }
}
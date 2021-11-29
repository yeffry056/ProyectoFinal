using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Entidades
{
    public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }
        public String  Nombre { get; set; }
        public String NombreUsuario { get; set; }
        public String Clave { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public int RolId { get; set; }

        [ForeignKey("RolId")]
        public Roles Rol { get; set; }
    }
}

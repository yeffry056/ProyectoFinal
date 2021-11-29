using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Entidades
{
    public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }
        public String Nombre { get; set; }
        public String Direccion { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public String Telefono { get; set; }
        public String Celular { get; set; }
        public String Cedula { get; set; }
        public String Email { get; set; }
        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuarios Usuario { get; set; }
    }
}

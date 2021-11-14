using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    }
}

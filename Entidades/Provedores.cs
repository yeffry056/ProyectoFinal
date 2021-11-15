using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Entidades
{
    public class Provedores
    {
        [Key]
        public int ProvedorId { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public String  Nombre { get; set; }
        public String Direccion { get; set; }
        public String Telefono { get; set; }
        
    }
}

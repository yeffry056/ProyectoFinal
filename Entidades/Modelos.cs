using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Entidades
{
    public class Modelos
    {
        [Key]
        public int ModeloId { get; set; }
        public String Modelo { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Entidades
{
    public class Vehiculos
    {
        [Key]
        public int VehiculoId { get; set; }
        public String  Marca { get; set; }
        public String  Modelo { get; set; }
        public String  Color { get; set; }
        public DateTime Feche { get; set; } = DateTime.Now;
        public String NumeracionChasis { get; set; }
        public int Año { get; set; }
    }
}

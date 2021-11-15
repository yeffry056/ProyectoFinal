using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Entidades
{
    public class Servicios
    {
        [Key]
        public int ServicioId { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public String Descripcion { get; set; }
        public float PrecioServicio { get; set; }
        public float Total { get; set; }
        /*
         ServicioId int primary key,
            Fecha date, 
            ClienteId int,
            VehiculoId int,
            Descripcion varchar(50),
            Estado varchar(30),
            Total float,
         */
    }
}

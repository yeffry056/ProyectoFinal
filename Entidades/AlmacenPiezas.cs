using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Entidades
{
    public class AlmacenPiezas
    {

        [Key]
        public int PiezaId { get; set; }
        public String  NombrePieza { get; set; }
        public String MarcaPieza { get; set; }
        public String Estado { get; set; }
        public String MarcaVehiculo { get; set; }
        public String ModeloVehiculo { get; set; }
        public int AñoVehiculo { get; set; }
        public float Costo { get; set; }
        public float Precio { get; set; }
        public int Cantidad { get; set; }
        
    }
}

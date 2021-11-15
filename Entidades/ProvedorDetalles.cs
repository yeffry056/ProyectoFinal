using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Entidades
{
    public class ProvedorDetalles
    {
        [Key]
        public int ProvedorDetalleId { get; set; }
        public String MarcaVahiculo { get; set; }
        public String ModeloVehiculo { get; set; }
        public int AñoVehiculo { get; set; }
        public String NombrePieza { get; set; }
        public String MarcaPieza { get; set; }
        public float Costo { get; set; }
        public int PiezaId { get; set; }
        public int Cantidad { get; set; }

        /* MarcaVahiculo varchar(30),
         ModeloVehiculo varchar(30),
         año int,
          varchar(30),
         MarcaPieza varchar(20),
         Costo int,
         PiezaId int,
         Cantidad int,*/
    }
}

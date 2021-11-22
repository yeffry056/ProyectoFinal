using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Entidades
{
    public class  VentasDetalle
    {
        [Key]
        public int DetalleId { get; set; }
        public int ArticuloId { get; set; }
        public int CantidadArticulo { get; set; }
        public int EmpleadoId { get; set; }
        public int VentaId { get; set; }
        public float Precio { get; set; }
        

        [ForeignKey("EmpleadoId")]
        public Empleados Empleado { get; set; }

        [ForeignKey("ArticuloId")]
        public Articulos Articulo { get; set; }
    }
}

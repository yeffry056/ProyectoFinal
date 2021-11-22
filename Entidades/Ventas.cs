using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Entidades
{
    public class Ventas
    {
        [Key]
        public int VentaId { get; set; }
        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }
        public int VehiculoId { get; set; }
        public int UsuarioId { get; set; }
        public String Descripcion { get; set; }
        public float Total { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuarios Usuario { get; set; }

        [ForeignKey("ClienteId")]
        public Clientes Cliente { get; set; }

        [ForeignKey("VentaId")]
        public List<VentasDetalle> Detalle { get; set; } = new List<VentasDetalle>();


    }
}

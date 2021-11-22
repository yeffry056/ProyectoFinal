using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Entidades
{
    public class Compras
    {
        [Key]
        public int CompraId { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public int ProveedorId { get; set; }
        public float Total { get; set; }
        public int Usuario { get; set; }

        [ForeignKey("CompraId")]
        public virtual List<CompraDetalle> CompraDetalles { get; set; } = new List<CompraDetalle>();
    }
}

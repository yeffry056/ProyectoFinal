using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Entidades
{
    public class CompraDetalle
    {
        [Key]
        public int Id { get; set; }
        public int CompraId { get; set; }
        public string Articulo { get; set; }
        public float Costo { get; set; }

        public CompraDetalle(int compraId, string articulo, float costo)
        {
            this.Id = 0;
            this.CompraId = compraId;
            this.Articulo = articulo;
            this.Costo = costo;
        }
    }
}

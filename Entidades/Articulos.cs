using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Entidades
{
    public class Articulos
    {
        [Key]
        public int ArticuloId { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public String Descripcion { get; set; }
        public String Estado { get; set; }
        public float Costo { get; set; }
        public float Precio { get; set; }
        public int Inventario { get; set; }
        public bool EsServicio { get; set; }

        public int FabricanteId { get; set; }

        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuarios Usuario { get; set; }

        [ForeignKey("FabricanteId")]
        public Fabricantes Fabricante { get; set; }
    }
}

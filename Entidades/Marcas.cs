using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Entidades
{
    public class Marcas
    {
        [Key]
        public int MarcaId { get; set; }
        public String Marca { get; set; }
        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuarios Usuario { get; set; }
        /*public int ModeloId { get; set; }
        [ForeignKey("ModeloId")]
        public Modelos Modelo { get; set; }*/
    }
}

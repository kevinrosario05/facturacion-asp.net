using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
    [Table("vendidos")]
    public class Vendidos
    {
        [Key]
        public int IdVendido { get; set; }
        
        [Column("Contador")]
        public int Contador { get; set; }
        [Column("IdPS")]
        public int IdPS { get; set; }
        [ForeignKey("IdPS")]
        public virtual Servicio Servicio { get; set; }

        [ForeignKey("IdPS")]
        public virtual Productos Productos { get; set; }

        [NotMapped]
        public string NombreProducto { get; set; }
        [NotMapped]
        public string NombreServicio { get; set; }
    }
}

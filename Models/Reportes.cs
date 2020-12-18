using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
    public class Reportes
    {
        [Key]
        public int IdReporte { get; set; }
        [Column(TypeName = "Nvarchar(100)")]
        [Required(ErrorMessage = "This field is required.")]
        public int ClienteId { get; set; }
        [Column(TypeName = "Nvarchar(100)")]
        public int IdProducto { get; set; }
        [Column(TypeName = "Nvarchar(100)")]
        public int IdServicio { get; set; }
    }
}

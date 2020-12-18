using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
    [Table("servicios")]
    public class Servicio
    {
        [Column("IdServicio"),Key]
        public int IdServicio { get; set; }
        [Column(TypeName = "Nvarchar(100)")]
        [Required(ErrorMessage = "This field is required.")]
        public string Nombre_Servic { get; set; }
        [Column(TypeName = "Nvarchar(100)")]
        public float Precio { get; set; }
        [Column(TypeName = "Nvarchar(100)")]
        public string Descripcion { get; set; }
        [Column(("Contador"), TypeName = "int")]
        public int Contador { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        [Column("ClienteId"),Key]
        public  int ClienteId { get; set; }
        [Column(TypeName = "Nvarchar(100)")]
        [Required (ErrorMessage ="This field is required.")]
        public string Rnc { get; set; }
        [Column(TypeName = "Nvarchar(100)")]
        public string Nombre { get; set; }
        [Column(TypeName = "Nvarchar(100)")]
        public string Direccion { get; set; }
        [Column(TypeName = "Nvarchar(100)")]
        public string Lat { get; set; }
        [Column(TypeName = "Nvarchar(100)")]
        public string Long { get; set; }
        [Column(TypeName = "Nvarchar(100)")]
        public string Telefono { get; set; }
        [Column(TypeName = "Nvarchar(100)")]
        public string Correo { get; set; }
        [Column("Contador")]
        public int? Contador { get; set; }
        [Column("MontoTotal")]
        public double? MontoTotal { get; set; }
        [Column("FechaCumpleaños")]
        public DateTime? FechaCumpleaños { get; set; }


    }
}

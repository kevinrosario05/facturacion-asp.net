using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Models
{
    [Table("facturas")]
    public class Factura
    {
        [Column("Idfactura"),Key]
        public int Idfactura { get; set; }
        [Column(TypeName = "int")]
        [Required(ErrorMessage = "This field is required.")]
        public int Cantidad_Art { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Descripcion { get; set; }

        [Column(TypeName = "float")]
        public float Precio { get; set; }
        [Column(TypeName = "float")]
        public float Itbis { get; set; }
        [Column(TypeName = "float")]
        public float Total { get; set; }
        [Column("SubTotal", TypeName = "float")]
        public float? SubTotal { get; set; }

        [Column(TypeName = "int")]
        public int ClienteId { get; set; }
        [NotMapped]
        [ForeignKey("ClienteId")]
        public virtual Cliente Cliente { get; set; }
        [NotMapped]
        public string NombreCliente { get; set; }

        [Column(TypeName = "int")]
        public int IdProducto { get; set; }
        [NotMapped]
        [ForeignKey("IdProducto")]
        public virtual Productos Productos { get; set; }
        [NotMapped]
        public string NombreProducto { get; set; }

        [Column(TypeName = "int")]
        public int IdServicio { get; set; }
        [NotMapped]
        [ForeignKey("IdServicio")]
        public virtual Servicio Servicio { get; set; }
        [NotMapped]
        public string NombreServicios { get; set; }

        [Column(TypeName ="DateTime")]
        public DateTime? FechaRegistro { get; set; }

        [Column(TypeName = "bit")]
        public bool Cancelada { get; set; }


    }
}

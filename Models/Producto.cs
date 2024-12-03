using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EjemploReporte.Models
{
    public class Producto
    {
        [Key] // Define la clave primaria
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Autoincrementable en la base de datos
        public int IdProducto { get; set; }
    //    //[Key]
    //    public int IdProducto { get; set; } // Clave primaria

    [Required]
        [MaxLength(50)]
        public string TipoProducto { get; set; }

        [Required]
        [MaxLength(50)]
        public string MarcaProducto { get; set; }

        [Required]
        [MaxLength(50)]
        public string ModeloProducto { get; set; }

        [Required]
        [MaxLength(50)]
        public string MedidasProducto { get; set; }

        [MaxLength(50)]
        public string? ColorProducto { get; set; }

        [Column(TypeName = "numeric(12, 2)")]
        public decimal? PrecioCosto { get; set; }

        [Column(TypeName = "numeric(12, 2)")]
        public decimal? PrecioVenta { get; set; }

        [Required]
        public bool EliminadoProducto { get; set; }

        [Column(TypeName = "numeric(12, 2)")]
        public decimal? Porcentaje { get; set; }
    }
}

//namespace EjemploReporte.Models
//{
//    public class Producto
//    {
//        public int IdProducto { get; set; } // Clave primaria
//        public string TipoProducto { get; set; }
//        public string MarcaProducto { get; set; }
//        public string ModeloProducto { get; set; }
//        public string MedidasProducto { get; set; }
//        public string? ColorProducto { get; set; }
//        public decimal? PrecioCosto { get; set; }
//        public decimal? PrecioVenta { get; set; }
//        public bool EliminadoProducto { get; set; }
//        public decimal? Porcentaje { get; set; }
//    }
//}

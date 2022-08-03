using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Datos.Models
{
    public class Factura : EntidadBase
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [DisplayName("Número de Factura")]
        public int NumeroDeFactura { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Importe { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual List<Producto> Productos { get; set; }

    }
}
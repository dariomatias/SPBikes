using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Datos.Models
{
    public class Producto : EntidadBase
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int SKU { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Nombre")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Descripcion")]
        public string Descripcion { get; set; }

    }

}
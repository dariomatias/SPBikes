using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Datos.Models
{
    public class Rol : EntidadBase
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Nombre")]
        public string Nombre { get; set; }
        
        [Required]
        [StringLength(100)]
        [DisplayName("Descripcion")]
        public string Descripcion { get; set; }
        
        public virtual Usuario Usuario { get; set; }
    }
}
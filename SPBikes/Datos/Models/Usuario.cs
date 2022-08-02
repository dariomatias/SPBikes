using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace Datos.Models
{
    public class Usuario : EntidadBase
    {
        public int Id { get; set; }
     
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Nombre")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Apellido")]
        public string Apellido { get; set; }

        [Required]
        [StringLength(100)]
        [RegexStringValidator("[A-Z,a-z, ,']{0,50} [0-9]{0,8}")]
        [DisplayName("Direccion")]
        public string Direccion { get; set; }

        [Required]
        [StringLength(50)]
        [RegexStringValidator("[0-9]{0,5}[-, ]{1}[0-9]{0,3}[-, ]{1}[0-9]{4}")]
        [DisplayName("Telefono")]
        public string Telefono { get; set; }
    }
}
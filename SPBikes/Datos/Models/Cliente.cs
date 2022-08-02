using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace Datos.Models
{
    public class Cliente : EntidadBase
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string RazonSocial { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Nombre")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Apellido")]
        public string Apellido { get; set; }

        [Key]
        [Required]
        [StringLength(15)]
        [RegexStringValidator("[0-9]{2}-[0-9]{6,8}-[0-9]{1}")]
        [DisplayName("CUIT")]
        public string CUIT { get; set; }

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
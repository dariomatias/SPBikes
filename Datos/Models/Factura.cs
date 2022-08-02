namespace Datos.Models
{
    public class Factura : EntidadBase
    {
        public int Id { get; set; }

        public virtual Cliente Cliente { get; set; }

    }
}
namespace Datos.Models
{
    public class Transaccion : EntidadBase
    {
        public int Id { get; set; }

        public virtual TipoTransaccion TipoTransaccion { get; set; }
        public virtual Factura Factura { get; set; }
    }
}
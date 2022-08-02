using System;

namespace Datos.Models
{
    public class Detalle : EntidadBase
    {
        public int Id { get; set; }
        public Decimal PrecioUnitario { get; set; }
        public int Cantidad { get; set; }
        public int Descuento { get; set; }

        public virtual Factura Factura { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
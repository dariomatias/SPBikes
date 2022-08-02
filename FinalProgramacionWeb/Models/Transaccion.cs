using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace FinalProgramacionWeb.Models
{
    public class Transaccion : EntidadBase
    {
        public int Id { get; set; }

        public virtual TipoTransaccion TipoTransaccion { get; set; }
        public virtual Factura Factura { get; set; }
    }
}
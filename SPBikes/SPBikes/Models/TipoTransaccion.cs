using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPBikes.Models
{
    public class TipoTransaccion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime FechaBaja { get; set; }
        public bool Activo { get; set; }
    }
}
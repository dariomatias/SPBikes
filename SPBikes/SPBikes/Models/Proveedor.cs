using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPBikes.Models
{
    public class Proveedor
    {
        public int Id { get; set; }
        public string RazonSocial { get; set; }
        public string CUIT { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime FechaBaja { get; set; }
        public bool Activo { get; set; }
    }
}
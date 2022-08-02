using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace FinalProgramacionWeb.Models
{
    public class EntidadBase
    {
        public SqlDateTime FechaAlta { get; set; }
        public SqlDateTime FechaBaja { get; set; }
        public bool Activo { get; set; }
    }
}
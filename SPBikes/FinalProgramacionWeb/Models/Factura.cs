using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProgramacionWeb.Models
{
    public class Factura : EntidadBase
    {
        public int Id { get; set; }

        public virtual Cliente Cliente { get; set; }

    }
}
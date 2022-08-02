using System.Data.SqlTypes;

namespace Datos.Models
{
    public class EntidadBase
    {
        public SqlDateTime FechaAlta { get; set; }
        public SqlDateTime FechaBaja { get; set; }
        public bool Activo { get; set; }
    }
}
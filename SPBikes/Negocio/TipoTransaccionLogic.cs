using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using Datos.Models;


namespace Negocio
{
    public static class TipoTransaccionLogic
    {
        private static ApplicationDbContext _context = new ApplicationDbContext();

        public static IEnumerable<TipoTransaccion> GetTipoTransacciones()
        {
            return _context.TiposTransacciones.OrderBy(tt => tt.Nombre).ToList();
        }

        public static TipoTransaccion GetTipoDeTransaccion(int? id)
        {
            return _context.TiposTransacciones.Find(id);
        }

    }
}

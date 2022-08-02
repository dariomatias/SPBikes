using System.Linq;
using System.Collections.Generic;
using Datos.Models;


namespace Negocio
{
    public static class RolLogic
    {
        public static IEnumerable<Rol> GetRoles(ApplicationDbContext db)
        {
            return db.Roles.OrderBy(r => r.Nombre).ToList();
        }

        public static Rol GetRol(int? id, ApplicationDbContext db)
        {
            return db.Roles.Find(id);
        }

    }
}

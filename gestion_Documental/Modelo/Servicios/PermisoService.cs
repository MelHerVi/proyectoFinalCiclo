using gestion_Documental.Modelo.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace gestion_Documental.Modelo.Servicios
{
    class PermisoService : ServicioGenerico<permisos>
    {
        public PermisoService(DbContext context) : base(context)
        {
        }
    }
}

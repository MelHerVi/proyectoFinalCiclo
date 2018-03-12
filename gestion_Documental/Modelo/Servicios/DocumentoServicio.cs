using gestion_Documental.Modelo.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestion_Documental.Modelo.Servicios
{
    class DocumentoServicio : ServicioGenerico<documentos>
    {
        public DocumentoServicio(DbContext context) : base(context)
        {
        }
    }
}

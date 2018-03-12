using gestion_Documental.Modelo.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestion_Documental.Modelo.Servicios
{
    class UsuarioServicio : ServicioGenerico<usuarios>
    {

        private DbContext contexto;


        public usuarios usuarioLogeado { get; set; }

        public UsuarioServicio(DbContext context) : base(context)
        {
            contexto = context;
        }

        /*
        * Método que comprueba las credenciales del usuario en la base de datos
        */
        public Boolean login(String user, String pass)
        {
            Boolean correcto = true;
            try
            {
                usuarioLogeado = contexto.Set<usuarios>().Where(u => u.username == user).FirstOrDefault();
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.StackTrace);
            }
            if (usuarioLogeado == null)
            {
                correcto = false;
            }
            else if (!usuarioLogeado.username.Equals(user) || !usuarioLogeado.password.Equals(pass))
            {
                correcto = false;
            }

            return correcto;
        }


        public Boolean usuarioUnico(string usu)
        {
            bool unico = true;
            if (contexto.Set<usuarios>().Where(u => u.username == usu).Count() > 0)
            {
                unico = false;
            }
            return unico;
        }


        /*
        * Devuelve un usuario en función del username pasado
        */
        public usuarios getUsuarioPorNombre(string nom)
        {
            usuarios usu;
            usu = contexto.Set<usuarios>().Where(u => u.username == nom).FirstOrDefault();
            return usu;
        }





    }
}

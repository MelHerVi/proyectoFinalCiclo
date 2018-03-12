using gestion_Documental.Modelo.DAL;
using gestion_Documental.Vista.Dialogos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace gestion_Documental
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private gestiondocumentalEntities gEnt;
        

        private void ApplicationStart(object sender, StartupEventArgs e)
        {

            // genero el object para la conexión con la BD
            gEnt = new gestiondocumentalEntities();

            // deshabilito el cierre de la app si cierro la ventana
            Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            
            // creo una instancia de la pantalla de login
            LoginDialog diagLogin = new LoginDialog(gEnt);



            // si el diálogo conecta con la BD y el usuario ha iniciado sesión
            if (diagLogin.ShowDialog() == true)
            {
                // creamos una instancia de la ventana principal con la conexión a la BD y el usuario conectado
                // para sacar la información correspondiente a posteriori
                MainWindow mainWindow = new MainWindow(gEnt, diagLogin.usuarioLogin);
                // vuelvo a activar el cierre
                Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
                // indicamos como ventana principal la mainwindow
                Current.MainWindow = mainWindow;
                // mostramos la mainwindow
                mainWindow.Show();


            }
            else
            {
                // si hay problemas con la conexión a la BD cierro la aplicación
                Application.Current.Shutdown();
          
            }

        }

    }
}

using gestion_Documental.Modelo.DAL;
using gestion_Documental.Modelo.Servicios;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace gestion_Documental.Vista.Dialogos
{
    /// <summary>
    /// Interaction logic for CambioPasswordDialog.xaml
    /// </summary>
    public partial class CambioPasswordDialog : Window
    {
        private gestiondocumentalEntities gEnt;
        private usuarios usuario;
        private UsuarioServicio usuService;
        private static Logger log = LogManager.GetCurrentClassLogger();

        public CambioPasswordDialog(gestiondocumentalEntities gEnt,usuarios usu)
        {
            InitializeComponent();
            this.gEnt = gEnt;
            usuario = usu;
            usuService = new UsuarioServicio(gEnt);
        }





        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            quitarError();

            if (string.IsNullOrEmpty(passActual.Password) && string.IsNullOrEmpty(passNueva.Password) && string.IsNullOrEmpty(passNuevaConfirmacion.Password))
            {
                lblPassActual.Content = "La contraseña actual es necesaria";
                imgPassActual.Visibility = Visibility.Visible;
                lblPassNueva.Content = "La contraseña nueva es necesaria";
                imgNuevaPass.Visibility = Visibility.Visible;
                lblPassNuevaConfirmacion.Content = "Es necesario confirmar la contraseña";
                imgNuevaPassConfirmacion.Visibility = Visibility.Visible;
            }
            else if (string.IsNullOrEmpty(passNueva.Password) && string.IsNullOrEmpty(passNuevaConfirmacion.Password))
            {
                lblPassNueva.Content = "La contraseña nueva es necesaria";
                imgNuevaPass.Visibility = Visibility.Visible;
                lblPassNuevaConfirmacion.Content = "Es necesario confirmar la contraseña";
                imgNuevaPassConfirmacion.Visibility = Visibility.Visible;
            }
            else if (string.IsNullOrEmpty(passActual.Password))
            {
                lblPassActual.Content = "La contraseña actual no puede estar vacía";
                imgPassActual.Visibility = Visibility.Visible;
            }
            else if (passActual.Password != usuario.password)
            {
                lblPassActual.Content = "La contraseña actual no coincide";
                imgPassActual.Visibility = Visibility.Visible;
            }
            else if (string.IsNullOrEmpty(passNueva.Password))
            {
                lblPassNueva.Content = "La nueva contraseña no puede estar vacía";
                imgNuevaPass.Visibility = Visibility.Visible;
            }
            else if (string.IsNullOrEmpty(passNuevaConfirmacion.Password))
            {
                lblPassNuevaConfirmacion.Content = "La confirmación de contraseña no puede estar en blanco";
                imgNuevaPassConfirmacion.Visibility = Visibility.Visible;
            }
            else if (passNueva.Password != passNuevaConfirmacion.Password)
            {
                lblPassNueva.Content = "Las contraseñas no coinciden";
                lblPassNuevaConfirmacion.Content = "Las contraseñas no coinciden";
                imgNuevaPass.Visibility = Visibility.Visible;
                imgNuevaPassConfirmacion.Visibility = Visibility.Visible;
            }
            else
            {
                try
                {
                    usuario.password = passNueva.Password;
                    usuService.edit(usuario);
                    usuService.save();
                    MessageBox.Show("Contraseña modificada correctamente", "Cambio de contraseña", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se ha podido modificar la contraseña, contacte con su administrador", "Cambio de contraseña", MessageBoxButton.OK, MessageBoxImage.Error);
                    log.Error("Intentando cambiar la contraseña de usuario", ex.StackTrace);
                }
            }
            
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void quitarError()
        {
            lblPassActual.Content = "";
            imgPassActual.Visibility = Visibility.Hidden;
            lblPassNueva.Content = "";
            imgNuevaPass.Visibility = Visibility.Hidden;
            lblPassNuevaConfirmacion.Content = "";
            imgNuevaPassConfirmacion.Visibility = Visibility.Hidden;
        }


    }
}

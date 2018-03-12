using gestion_Documental.Modelo.DAL;
using gestion_Documental.Modelo.Servicios;
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
    /// Interaction logic for LoginDialog.xaml
    /// </summary>
    public partial class LoginDialog : Window
    {

        private UsuarioServicio usuService;
        private gestiondocumentalEntities gEnt;



        public LoginDialog(gestiondocumentalEntities gEnt)
        {
            InitializeComponent();
            this.gEnt = gEnt;
            usuService = new UsuarioServicio(gEnt);
            gEnt.Database.Connection.Open();

        }


        public usuarios usuarioLogin
        {
            get
            {
                return usuService.usuarioLogeado;
            }
        }


        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            quitarError();


            if (String.IsNullOrEmpty(txtNombreUsuario.Text) && String.IsNullOrEmpty(pwdPassword.Password))
            {
                mostrarError("Usuario y contraseña vacíos", Visibility.Visible, Visibility.Visible);

            }
            else if (String.IsNullOrEmpty(txtNombreUsuario.Text))
            {
                mostrarError("El usuario no puede estar vacío", Visibility.Visible, Visibility.Hidden);
            }
            else if (String.IsNullOrEmpty(pwdPassword.Password))
            {
                mostrarError("La contraseña no puede estar vacía", Visibility.Hidden, Visibility.Visible);
            }
            else
            {
                if (usuService.login(txtNombreUsuario.Text, pwdPassword.Password))
                {
                    this.DialogResult = true;
                }
                else
                {
                    mostrarError("Error al validar usuario / contraseña", Visibility.Visible, Visibility.Visible);
                }

            }



        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }


        /*
          Activa las imágenes y el mensaje de error
        */
        private void mostrarError(string msg, Visibility visNombre, Visibility visPass)
        {
            txtMensajeError.Text = msg;
            imgNombreUsuario.Visibility = visNombre;
            imgPassword.Visibility = visPass;

        }

        /*
         Quita las imágenes y el mensaje de error
         */
        private void quitarError()
        {
            txtMensajeError.Text = "";
            imgNombreUsuario.Visibility = Visibility.Hidden;
            imgPassword.Visibility = Visibility.Hidden;
        }



    }
}

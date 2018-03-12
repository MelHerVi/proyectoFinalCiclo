using gestion_Documental.Modelo.DAL;
using gestion_Documental.Vista.ControlesUsuario;
using gestion_Documental.Vista.Dialogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace gestion_Documental
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private gestiondocumentalEntities gEnt;
        private usuarios usuarioConectado;
        private DispatcherTimer timer;
      
        public MainWindow(gestiondocumentalEntities gEnt,usuarios usu)
        {
            InitializeComponent();
            this.gEnt = gEnt;
            usuarioConectado = usu;
            btnNombreUsuario.Content = usuarioConectado.nombre.ToString();

            // para el reloj
            timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                this.txtHora.Text = DateTime.Now.ToString("HH:mm:ss");
            }, this.Dispatcher);

            // para la fecha
            txtFecha.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            
        }

    /*
        Método para el botón con el nombre de usuario 
    */
        private void btnNombreUsuario_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).ContextMenu.IsEnabled = true;
            (sender as Button).ContextMenu.PlacementTarget = (sender as Button);
            (sender as Button).ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            (sender as Button).ContextMenu.IsOpen = true;
        }

        private void btnModificarPass_Click(object sender, RoutedEventArgs e)
        {
            CambioPasswordDialog cmbPass = new CambioPasswordDialog(gEnt, usuarioConectado);
            cmbPass.ShowDialog();
        }

        private void btnPanelAdministracion_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
            
        }

        private void btnConciertos_Click(object sender, RoutedEventArgs e)
        {
            UCListaDocumentos ucLista = new UCListaDocumentos(gEnt);
            if (gridCentral.Children != null) gridCentral.Children.Clear();
            gridCentral.Children.Add(ucLista);
        }

        private void btnInformes_Click(object sender, RoutedEventArgs e)
        {
            //sin implementar
        }

        private void btnGraficos_Click(object sender, RoutedEventArgs e)
        {
            // sin implementar
        }
    }
}

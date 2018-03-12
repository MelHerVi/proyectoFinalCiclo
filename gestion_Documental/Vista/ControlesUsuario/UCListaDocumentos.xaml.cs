using gestion_Documental.Modelo.DAL;
using gestion_Documental.MVVM;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace gestion_Documental.Vista.ControlesUsuario
{
    /// <summary>
    /// Interaction logic for UCListaDocumentos.xaml
    /// </summary>
    public partial class UCListaDocumentos : UserControl
    {
        private gestiondocumentalEntities gEnt;
        private MVListaConciertos mvConciertos;
    
        public UCListaDocumentos(gestiondocumentalEntities gEnt)
        {
            InitializeComponent();
            this.gEnt = gEnt;
            mvConciertos = new MVListaConciertos(gEnt);
            this.DataContext = mvConciertos;
             
         
        }

        private void btnAnyadir_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnImprimir_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog dlg = new PrintDialog();
            if ((bool)dlg.ShowDialog().GetValueOrDefault())
            {
                Size pageSize = new Size(dlg.PrintableAreaWidth, dlg.PrintableAreaHeight);                
                dlg.PrintVisual(dtgDocumentos, "LISTA DE CONCIERTOS");

            }
        }

        private void cmbEmpresa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mvConciertos.listaDocumentos.Filter = new Predicate<Object>(mvConciertos.filtroEmpresa);
        }

        private void cmbResponsable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mvConciertos.listaDocumentos.Filter = new Predicate<object>(mvConciertos.filtroResponsable);
        }

        private void filtroFecha_Click(object sender, RoutedEventArgs e)
        {
            if (mvConciertos.fechaInicial > mvConciertos.fechaFinal)
            {
                MessageBox.Show("La fecha inicial no puede ser mayor que la fecha final", "Filtro fechas", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                mvConciertos.listaDocumentos.Filter = new Predicate<object>(mvConciertos.filtroFecha);
            }
        }

        private void limpiarfiltro_Click(object sender, RoutedEventArgs e)
        {
            cmbEmpresa.Text= "Selecciona una empresa";
            cmbResponsable.Text = "Selecciona un responsable";
            mvConciertos.listaDocumentos.Filter = null;
        }

        private void btnEditarConcierto_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEliminarConcierto_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnVerDocumento_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

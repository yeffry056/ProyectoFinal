using ProyectoFinal.BLL;
using ProyectoFinal.Entidades;
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

namespace ProyectoFinal.UI.Consultas
{
    /// <summary>
    /// Interaction logic for cCompra.xaml
    /// </summary>
    public partial class cCompra : Window
    {
        public cCompra()
        {
            InitializeComponent();
        }

        private void ConsultaClick(object sender, RoutedEventArgs e)
        {
            var listado = new List<Compras>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: //CompraId
                        listado = CompraBLL.GetList(e => e.CompraId == Utilidades.ToInt(CriterioTextBox.Text));
                        break;

                    case 1: //Nombre                      
                        //listado = CompraBLL.GetList(e => e.ProveedorId.ToLower().Contains(CriterioTextBox.Text.ToLower()));
                        break;
                }
            }
            else
            {
                listado = CompraBLL.GetList(c => true);
            }

            if (DesdeDataPicker.SelectedDate != null)
                listado = CompraBLL.GetList(c => c.Fecha.Date >= DesdeDataPicker.SelectedDate);

            if (HastaDatePicker.SelectedDate != null)
                listado = CompraBLL.GetList(c => c.Fecha.Date <= HastaDatePicker.SelectedDate);

            // listado = UsuariosBLL.GetList();
            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}

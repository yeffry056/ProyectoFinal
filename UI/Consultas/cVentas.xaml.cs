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
    /// Interaction logic for cVentas.xaml
    /// </summary>
    public partial class cVentas : Window
    {
        public cVentas()
        {
            InitializeComponent();
        }
        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Ventas>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: //UsuarioId
                        listado = VentaBLL.GetList(e => e.ClienteId == Utilidades.ToInt(CriterioTextBox.Text));
                        break;

                    case 1: //Nombre                      
                        listado = VentaBLL.GetList(e => e.Descripcion.ToLower().Contains(CriterioTextBox.Text.ToLower()));
                        break;
                }
            }
            else
            {
                listado = VentaBLL.GetList(c => true);
            }

            if (DesdeDataPicker.SelectedDate != null)
                listado = VentaBLL.GetList(c => c.Fecha.Date >= DesdeDataPicker.SelectedDate);

            if (HastaDatePicker.SelectedDate != null)
                listado = VentaBLL.GetList(c => c.Fecha.Date <= HastaDatePicker.SelectedDate);

            // listado = UsuariosBLL.GetList();
            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}

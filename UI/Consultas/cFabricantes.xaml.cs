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
    /// Interaction logic for cFabricantes.xaml
    /// </summary>
    public partial class cFabricantes : Window
    {
        public cFabricantes()
        {
            InitializeComponent();
        }
        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Fabricantes>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: //UsuarioId
                        listado = FabricanteBLL.GetList(e => e.FabricanteId == Utilidades.ToInt(CriterioTextBox.Text));
                    
                       
                        break;

                    case 1: //Nombre                      
                        listado = FabricanteBLL.GetList(e => e.Nombres.ToLower().Contains(CriterioTextBox.Text.ToLower()));
                        
                        break;
                }
            }
            else
            {
                listado = FabricanteBLL.GetList(c => true);
            }

            

            // listado = UsuariosBLL.GetList();
            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}

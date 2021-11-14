using ProyectoFinal.UI.Consultas;
using ProyectoFinal.UI.Registros;
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

namespace ProyectoFinal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void RegistrosClik(object sender, RoutedEventArgs e)
        {
            rUsuario usuario = new rUsuario();
            usuario.Show();
        }

        private void ConsultaUsuario(object sender, RoutedEventArgs e)
        {
            cUsuario c = new cUsuario();
            c.Show();
        }

        private void rClientesClik(object sender, RoutedEventArgs e)
        {
            rCliente cliente = new rCliente();
            cliente.Show();
        }

        private void cClientesClick(object sender, RoutedEventArgs e)
        {
            cCliente cliente = new cCliente();
            cliente.Show();
        }
    }
}

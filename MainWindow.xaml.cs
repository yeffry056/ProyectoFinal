using ProyectoFinal.Entidades;
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

        private void EmpleadosClick(object sender, RoutedEventArgs e)
        {
            rEmpleado empleado = new rEmpleado();
            empleado.Show();
        }

        private void ConsultaEmpleado(object sender, RoutedEventArgs e)
        {
            cEmpleado cEmpleado = new cEmpleado();
            cEmpleado.Show();
        }

        private void VehiculosClick(object sender, RoutedEventArgs e)
        {
            rVehiculo vehiculo = new rVehiculo();
            vehiculo.Show();
        }

        private void ConsultaVehiculo(object sender, RoutedEventArgs e)
        {
            cVehiculo cVehiculo = new cVehiculo();
            cVehiculo.Show();
        }

        private void ComprasClick(object sender, RoutedEventArgs e)
        {
            rCompra rCompra = new rCompra();
            rCompra.Show();
        }

        private void ConsultaCompra(object sender, RoutedEventArgs e)
        {
            cCompra cCompra = new cCompra();
            cCompra.Show();
        }

        private void RolesClic(object sender, RoutedEventArgs e)
        {
            rRol rRol = new rRol();
            rRol.Show();
        }

        private void ConsultaRol(object sender, RoutedEventArgs e)
        {
            cRol cRol = new cRol();
            cRol.Show();
        }
    }
}

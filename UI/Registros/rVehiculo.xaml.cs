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

namespace ProyectoFinal.UI.Registros
{
    /// <summary>
    /// Interaction logic for rVehiculo.xaml
    /// </summary>
    public partial class rVehiculo : Window
    {
        private Vehiculos vehiculo = new Vehiculos();
        public rVehiculo()
        {
            InitializeComponent();
            this.DataContext = vehiculo;
        }

        private void Limpiar()
        {
            this.vehiculo = new Vehiculos();
            this.DataContext = vehiculo;
            FechaIngresoDatePicker.SelectedDate = DateTime.Now;
            //TextClave.Password = string.Empty;
            //CheckActivo.IsChecked = false;
        }
        
        private bool Validar()
        {
            bool esValido = true;
            if (TextBoxVehiculoId.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return esValido;
            }
            if (TextBoxMarca.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return esValido;
            }
            if (TextBoxModelo.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return esValido;
            }
            if (TextBoxColor.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return esValido;
            }
            if (TextBoxAño.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return esValido;
            }
            if (TextBoxChasis.Text.Length == 0)
            {
                 esValido = false;
                 MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return esValido;
            }
            return esValido;
        }

        private void BtnBuscar(object sender, RoutedEventArgs e)
        {
            if (TextBoxVehiculoId.Text.Length == 0)
            {

                MessageBox.Show("ID vacio", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else if (!VehiculoBLL.Existe(Convert.ToInt32(TextBoxVehiculoId.Text)))
            {
                Limpiar();
                MessageBox.Show("El registro no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var vehiculo = VehiculoBLL.Buscar(Convert.ToInt32(TextBoxVehiculoId.Text));
            if (vehiculo != null)
            {
                Limpiar();
                this.vehiculo = vehiculo;

            }
            else
                Limpiar();

            /* if (usuario.Activo == CheckActivo.Content.ToString())
                 CheckActivo.IsChecked = true;*/


            this.DataContext = this.vehiculo;
        }

        private void BtnNuevo(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void BtnGuardar(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;
            // usuario.Clave = TextClave.Password;
            var paso = VehiculoBLL.Guardar(vehiculo);

            if (paso)
            {

                Limpiar();
                MessageBox.Show("Transaccion Exitosa", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
                MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void BtnEliminar(object sender, RoutedEventArgs e)
        {
            if (VehiculoBLL.Eliminar(Convert.ToInt32(TextBoxVehiculoId.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible eliminar el registro", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}

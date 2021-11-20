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
    /// Interaction logic for rCompra.xaml
    /// </summary>
    public partial class rCompra : Window
    {
        private Compras Compra = new Compras();
        public rCompra()
        {
            InitializeComponent();
            this.DataContext = Compra;
        }

        private void Limpiar()
        {
            this.Compra = new Compras();
            this.DataContext = Compra;
            FechaIngresoDatePicker.SelectedDate = DateTime.Now;
        }

        private bool Validar()
        {
            bool esValido = true;
            if (TextBoxCompraId.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return esValido;
            }
            if (TextBoxProveedorId.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return esValido;
            }
            if (TextBoxTotal.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return esValido;
            }
            if (TextBoxUsuario.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return esValido;
            }
            return esValido;
        }

        private void BtnBuscar(object sender, RoutedEventArgs e)
        {
            if (TextBoxCompraId.Text.Length == 0)
            {

                MessageBox.Show("ID vacio", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else if (!CompraBLL.Existe(Convert.ToInt32(TextBoxCompraId.Text)))
            {
                Limpiar();
                MessageBox.Show("El registro no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var compra = CompraBLL.Buscar(Convert.ToInt32(TextBoxCompraId.Text));
            if (compra != null)
            {
                Limpiar();
                this.Compra = compra;
            }
            else
                Limpiar();

            this.DataContext = this.Compra;
        }

        private void BtnNuevo(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void BtnGuardar(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = CompraBLL.Guardar(Compra);

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
            if (CompraBLL.Eliminar(Convert.ToInt32(TextBoxCompraId.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible eliminar el registro", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}

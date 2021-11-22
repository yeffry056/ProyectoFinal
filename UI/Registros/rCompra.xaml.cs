using ProyectoFinal.BLL;
using ProyectoFinal.Entidades;
using ProyectoFinal.UI.Consultas;
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
        //private CompraDetalle c = new CompraDetalle();
        public rCompra()
        {
            InitializeComponent();
            this.DataContext = Compra;
            //
            TextBoxCompraId.Text = "0";
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

            return esValido;
        }

        private void BtnBuscar(object sender, RoutedEventArgs e)
        {
            if (TextBoxCompraId.Text.Length == 0)
            {

                MessageBox.Show("CompraId vacio", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var compra = CompraBLL.Buscar(Convert.ToInt32(TextBoxCompraId.Text));
            if (compra != null)
            {
                Limpiar();
                this.Compra = compra;
                this.TextBoxTotal = TextBoxCosto;
            }
            else
                Limpiar();

            this.DataContext = this.Compra;
        }

        private void BtnNuevo(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Compras esValido = CompraBLL.Buscar(Compra.CompraId);

            return (esValido != null);
        }

        private void BtnGuardar(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = CompraBLL.Guardar(Compra);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado!!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Guardado Negado", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);

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

        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = Compra;
        }

        private void BtnAgregarFila(object sender, RoutedEventArgs e)
        {
            if (TextBoxCompraId.Text.Length == 0)
            {
                MessageBox.Show("CompraId vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (TextBoxCosto.Text.Length == 0)
            {
                MessageBox.Show("Costo vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (texBoxArticulo.Text.Length == 0)
            {
                MessageBox.Show("Articulo vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                Compra.CompraDetalles.Add(new CompraDetalle( Compra.CompraId, texBoxArticulo.Text, Convert.ToSingle(TextBoxCosto.Text)));
                //Tarea.Detalle.Add(new TareasDetalle(Tarea.TareaId, RequerimientoTextBox.Text, Convert.ToSingle(ValorTextBox.Text)));
                Cargar();

                //TextBoxDetalleId.Focus();
                //TextBoxDetalleId.Clear();
                //TextBoxDetalleId.Focus();
                texBoxArticulo.Focus();
                TextBoxCosto.Clear();
                texBoxArticulo.Clear();
            }
        
        }

        private void BtnRemoverFila(object sender, RoutedEventArgs e)
        {
            if (Contenido.Items.Count >= 1 && Contenido.SelectedIndex <= Contenido.Items.Count - 1)
            {
                Compra.CompraDetalles.RemoveAt(Contenido.SelectedIndex);
                Cargar();
            }
        }
    }
}

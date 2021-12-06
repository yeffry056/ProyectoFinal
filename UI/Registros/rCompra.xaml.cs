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
        public rCompra(List<Usuarios> usuarioInicio)
        {
            InitializeComponent();
            this.DataContext = Compra;
            
            TextBoxCompraId.Text = "0";

            UsuarioComboBox.ItemsSource = usuarioInicio.ToArray();
            UsuarioComboBox.SelectedValuePath = "UsuarioId";
            UsuarioComboBox.DisplayMemberPath = "Nombre";
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
                TextBoxCompraId.Focus();
                return esValido;
            }
            if (UsuarioComboBox.SelectedValue == null)
            {
                esValido = false;
                MessageBox.Show("Seleccione el usuario", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
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
            if(TextBoxCompraId.Text.Length == 0)
            {
                MessageBox.Show("No se pudo eliminar el registro", "Exito", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
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
            
            
            Compra.CompraDetalles.Add(new CompraDetalle( Compra.CompraId, texBoxArticulo.Text, Convert.ToSingle(TextBoxCosto.Text)));
           
            Cargar();
            TextBoxTotal.Text = Compra.CompraDetalles.Sum(x => x.Costo).ToString();


            texBoxArticulo.Focus();
            TextBoxCosto.Clear();
            texBoxArticulo.Clear();
            
        
        }

        private void BtnRemoverFila(object sender, RoutedEventArgs e)
        {
            if (Contenido.Items.Count >= 1 && Contenido.SelectedIndex <= Contenido.Items.Count - 1)
            {
                if(Contenido.SelectedValue == null)
                {
                    MessageBox.Show("Seleccione la fila que desea eliminar", "Fallo",
                   MessageBoxButton.OK, MessageBoxImage.Error);
                    Contenido.Focus();
                    return;
                }
                Compra.CompraDetalles.RemoveAt(Contenido.SelectedIndex);
                Cargar();
            }
        }
    }
}

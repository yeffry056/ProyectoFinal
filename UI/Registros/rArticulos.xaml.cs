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
    /// Interaction logic for rArticulos.xaml
    /// </summary>
    public partial class rArticulos : Window
    {
        private Articulos articulo = new Articulos();
        public rArticulos()
        {
            InitializeComponent();
            this.DataContext = articulo;

            FabricanteComboBox.ItemsSource = FabricanteBLL.GetListido();
            FabricanteComboBox.SelectedValuePath = "FabricanteId";
            FabricanteComboBox.DisplayMemberPath = "Nombres";

            UsuarioComboBox.ItemsSource = UsuarioBLL.GetListido();
            UsuarioComboBox.SelectedValuePath = "UsuarioId";
            UsuarioComboBox.DisplayMemberPath = "Nombre";
        }
        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = articulo;

        }
        private void Limpiar()
        {
            this.articulo = new Articulos();
            this.DataContext = articulo;
        }
        private bool Validar()
        {
            bool esValido = true;
            if (TextArticuloId.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return esValido;

            }
            if (TextDescripcion.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return esValido;

            }
            if (TextEstado.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return esValido;

            }
            if (TextCosto.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return esValido;

            }
            if (TextPrecio.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return esValido;

            }
            if (TextInventario.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return esValido;

            }

            return esValido;
        }
        private void BtnBuscar(object sender, RoutedEventArgs e)
        {

            var encontrado = ArticuloBLL.Buscar(articulo.ArticuloId);

            if (encontrado != null)
            {
                articulo = encontrado;
                Cargar();
                //TextTotal.Text = venta.Detalle.Sum(x => x.Tiempo).ToString();
            }
            else
            {
                Limpiar();
                MessageBox.Show("Venta no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnAgregarFila(object sender, RoutedEventArgs e)
        {
            /*proyecto.Detalle.Add(new DetalleTarea
            {
                ProyectoId = proyecto.ProyectoId,
                tipoTarea = (TipoTarea)TareaComboBox.SelectedItem,
                Tiempo = Utilidades.ToInt(TextMinutos.Text),
                TiempoTotal = proyecto.Detalle.Sum(e => e.Tiempo),
                Requerimiento = TextRequerimiento.Text
            });

            Cargar();
            TextTotal.Text = Convert.ToString(proyecto.Detalle.Sum(e => e.Tiempo));

            TextRequerimiento.Focus();
            TextRequerimiento.Clear();
            TextMinutos.Clear();*/

        }

        private void BtnRemoverFila(object sender, RoutedEventArgs e)
        {
            /*if (DetalleDataGrid.Items.Count >= 1 && DetalleDataGrid.SelectedIndex <= DetalleDataGrid.Items.Count - 1)
            {
                venta.Detalle.RemoveAt(DetalleDataGrid.SelectedIndex);
                Cargar();
            }*/
        }

        private void BtnNuevo(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void BtnGuardar(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;
            var paso = ArticuloBLL.Guardar(articulo);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No se pudo guardar", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);

        }

        private void BtnEliminar(object sender, RoutedEventArgs e)
        {
            var existe = ArticuloBLL.Buscar(articulo.ArticuloId);

            if (existe == null)
            {
                MessageBox.Show("No existe el proyecto", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                ArticuloBLL.Eliminar(articulo.ArticuloId);
                MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);

            }
        }
    }
}

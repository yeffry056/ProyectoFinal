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
    /// Interaction logic for rVentas.xaml
    /// </summary>
    public partial class rVentas : Window
    {
        private Ventas venta = new Ventas();
        public rVentas(List<Usuarios> UsuarioInicio)
        {
            InitializeComponent();
            this.DataContext = venta;

            
            ClienteComboBox.ItemsSource = ClienteBLL.GetClientes();
            ClienteComboBox.SelectedValuePath = "ClienteId";
            ClienteComboBox.DisplayMemberPath = "Nombre";

            UsuarioComboBox.ItemsSource = UsuarioInicio.ToArray();
            UsuarioComboBox.SelectedValuePath = "UsuarioId";
            UsuarioComboBox.DisplayMemberPath = "Nombre";
           

            ArticuloComboBox.ItemsSource = ArticuloBLL.GetListado();
            ArticuloComboBox.SelectedValuePath = "ArticuloId";
            ArticuloComboBox.DisplayMemberPath = "Descripcion";


            VehiculoComboBox.ItemsSource = VehiculoBLL.GetListado();
            VehiculoComboBox.SelectedValuePath = "VehiculoId";
            VehiculoComboBox.DisplayMemberPath = "Marca";

            EmpleadoComboBox.ItemsSource = EmpleadoBLL.GetListado();
            EmpleadoComboBox.SelectedValuePath = "EmpleadoId";
            EmpleadoComboBox.DisplayMemberPath = "Nombre";

        }
        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = venta;

        }
        private void Limpiar()
        {
            this.venta = new Ventas();
            this.DataContext = venta;
        }
        private bool Validar()
        {
            bool esValido = true;
            if (TextVentaId.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                TextVentaId.Focus();
                return esValido;

            }
           
            if (ClienteComboBox.SelectedValue == null)
            {
                esValido = false;
                MessageBox.Show("Seleccione un cliente", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return esValido;
            }

            if (VehiculoComboBox.SelectedValue == null)
            {
                esValido = false;
                MessageBox.Show("Seleccione un vehiculo", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return esValido;
            }
            if (UsuarioComboBox.SelectedValue == null)
            {
                esValido = false;
                MessageBox.Show("Seleccione el usuario", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return esValido;
            }
            if (TextDescripcion.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Descripcion vacia", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                TextDescripcion.Focus();
                return esValido;

            }
            
           

            return esValido;
        }
        private void BtnBuscar(object sender, RoutedEventArgs e)
        {

            var encontrado = VentaBLL.Buscar(venta.VentaId);

            if (encontrado != null)
            {
                venta = encontrado;
                Cargar();
               
            }
            else
            {
                Limpiar();
                MessageBox.Show("Venta no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private bool ValidarAgregar()
        {
            bool esValido = true;
            if (TextVentaId.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return esValido;

            }
            if (EmpleadoComboBox.SelectedValue == null)
            {
                esValido = false;
                MessageBox.Show("Seleccione un empleado", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return esValido;
            }
            if (ClienteComboBox.SelectedValue == null)
            {
                esValido = false;
                MessageBox.Show("Seleccione un cliente", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return esValido;
            }

            if (VehiculoComboBox.SelectedValue == null)
            {
                esValido = false;
                MessageBox.Show("Seleccione un vehiculo", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return esValido;
            }
            if (UsuarioComboBox.SelectedValue == null)
            {
                esValido = false;
                MessageBox.Show("Seleccione el usuario", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return esValido;
            }
            if (TextDescripcion.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Descripcion vacia", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                TextDescripcion.Focus();
                return esValido;

            }
            
            if(ArticuloComboBox.SelectedValue == null)
            {
                esValido = false;
                MessageBox.Show("Seleccione un articulo", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return esValido;
            }
            if (TextCantidadArticulo.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Cantidad vacia", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                TextCantidadArticulo.Focus();
                return esValido;
            }
            if (TextPrecio.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Precio vacio", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                TextPrecio.Focus();
                return esValido;
            }
            
            return esValido;
        }
        private void BtnAgregarFila(object sender, RoutedEventArgs e)
        {
            if (!ValidarAgregar())
                return;

            venta.Detalle.Add(new VentasDetalle
            {
                 VentaId = venta.VentaId,
                 Articulo = (Articulos)ArticuloComboBox.SelectedItem,
                 Empleado = (Empleados)EmpleadoComboBox.SelectedItem,
                 CantidadArticulo = Utilidades.ToInt(TextCantidadArticulo.Text),
                 Precio = Utilidades.ToInt(TextPrecio.Text),
            });
               
            

            Cargar();
           

            TextCantidadArticulo.Clear();
            TextCantidadArticulo.Focus();
            TextPrecio.Clear();
            

        }

        private void BtnRemoverFila(object sender, RoutedEventArgs e)
        {
            if (DetalleDataGrid.Items.Count >= 1 && DetalleDataGrid.SelectedIndex <= DetalleDataGrid.Items.Count - 1)
            {
                if(DetalleDataGrid.SelectedValue == null)
                {
                    MessageBox.Show("Seleccione la fila que desea eliminar", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                venta.Detalle.RemoveAt(DetalleDataGrid.SelectedIndex);
                Cargar();
            }
        }

        private void BtnNuevo(object sender, RoutedEventArgs e)
        {
           
            Limpiar();
        }

        private void BtnGuardar(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;
            var paso = VentaBLL.Guardar(venta);

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
            var existe = VentaBLL.Buscar(venta.VentaId);

            if (existe == null)
            {
                MessageBox.Show("No existe el proyecto", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                VentaBLL.Eliminar(venta.VentaId);
                Limpiar();
                MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);

            }
        }
    }
}

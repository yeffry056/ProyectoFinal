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
    /// Interaction logic for rCliente.xaml
    /// </summary>
    public partial class rCliente : Window
    {
        private Clientes cliente = new Clientes();
        public rCliente(List<Usuarios> usuarioInicio)
        {
            InitializeComponent();
            this.DataContext = cliente;



            UsuarioComboBox.ItemsSource = usuarioInicio.ToArray();
            UsuarioComboBox.SelectedValuePath = "UsuarioId";
            UsuarioComboBox.DisplayMemberPath = "Nombre";
        }
        private void BtnBuscar(object sender, RoutedEventArgs e)
        {
            if (TextClienteId.Text.Length == 0)
            {

                MessageBox.Show("ID vacio", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else if (!UsuarioBLL.Existe(Convert.ToInt32(TextClienteId.Text)))
            {
                Limpiar();
                MessageBox.Show("El registro no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var cliente = ClienteBLL.Buscar(Convert.ToInt32(TextClienteId.Text));
            if (cliente != null)
            {
                Limpiar();
                this.cliente = cliente;

            }
            else
            {
                MessageBox.Show("El registro no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                Limpiar();
               
            }
               

           

            this.DataContext = this.cliente;
        }

        private void BtnNuevo(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
        private void Limpiar()
        {
            this.cliente = new Clientes();
            this.DataContext = cliente;
            FechaIngresoDatePicker.SelectedDate = DateTime.Now;
            
        }
        private bool Validar()
        {
            bool esValido = true;
            if (TextClienteId.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                TextClienteId.Focus();
                return esValido;
            }
            if (TextDireccion.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                TextDireccion.Focus();
                return esValido;
            }
            if (TextNombre.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                TextNombre.Focus();
                return esValido;
            }
           
            if (TextTelefono.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                TextTelefono.Focus();
                return esValido;
            }
            if (TextCelular.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                TextCelular.Focus();
                return esValido;
            }
            if (TextCedula.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                TextCedula.Focus();
                return esValido;
            }
            if (UsuarioComboBox.SelectedValue == null)
            {
                esValido = false;
                MessageBox.Show("Seleccione el usuario", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return esValido;
            }
            if (!Utilidades.Validar_Email(TextEmail.Text))
            {
                esValido = false;
                MessageBox.Show("Email no valido ", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                TextEmail.Focus();
                return esValido;
            }

            return esValido;
        }
        private void BtnGuardar(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;
            

            
            var paso = ClienteBLL.Guardar(cliente);

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
            if(TextClienteId.Text.Length == 0)
            {
                MessageBox.Show("ClienteId vacio", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            

            if (ClienteBLL.Eliminar(Convert.ToInt32(TextClienteId.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible eliminar el registro", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    
    }
}

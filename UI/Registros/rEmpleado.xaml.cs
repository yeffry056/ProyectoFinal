using ProyectoFinal.BLL;
using System;
using ProyectoFinal.Entidades;
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
    /// Interaction logic for rEmpleado.xaml
    /// </summary>
    public partial class rEmpleado : Window
    {
        private Empleados empleado = new Empleados();
        public rEmpleado(List<Usuarios> usuarioInicio)
        {
            InitializeComponent();
            this.DataContext = empleado;


            UsuarioComboBox.ItemsSource = usuarioInicio.ToArray();
            UsuarioComboBox.SelectedValuePath = "UsuarioId";
            UsuarioComboBox.DisplayMemberPath = "Nombre";
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
            var paso = EmpleadoBLL.Guardar(empleado);

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
            if (EmpleadoBLL.Eliminar(Convert.ToInt32(TextBoxEmpleadoId.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible eliminar el registro", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
        }
         
        private void BtnBuscar(object sender, RoutedEventArgs e)
        {
            if (TextBoxEmpleadoId.Text.Length == 0)
            {

                MessageBox.Show("ID vacio", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else if (!EmpleadoBLL.Existe(Convert.ToInt32(TextBoxEmpleadoId.Text)))
            {
                Limpiar();
                MessageBox.Show("El registro no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var empleado = EmpleadoBLL.Buscar(Convert.ToInt32(TextBoxEmpleadoId.Text));
            if (empleado != null)
            {
                Limpiar();
                //this.cliente = cliente;
                  this.empleado = empleado;

            }
            else
                Limpiar();


            this.DataContext = this.empleado;

        }

        private void Limpiar()
        {
            this.empleado = new Empleados();
            this.DataContext = empleado;
            FechaDatePicker.SelectedDate = DateTime.Now;


        }

        private bool Validar()
        {
            bool esValido = true;
            if (TextBoxEmpleadoId.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return esValido;
            }
            if (TextBoxDireccion.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return esValido;
            }
            if (TextBoxNombre.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return esValido;
            }

            if (TextBoxTelefono.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return esValido;
            }

            if (TextBoxCedula.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return esValido;
            }

            if (TextBoxEncargado.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
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
    }
}

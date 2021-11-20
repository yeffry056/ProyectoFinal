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
    /// Interaction logic for rRol.xaml
    /// </summary>
    public partial class rRol : Window
    {
        private Roles Rol = new Roles();
        public rRol()
        {
            InitializeComponent();
            this.DataContext = Rol;
        }

        private void BtnBuscar(object sender, RoutedEventArgs e)
        {
            if (TextRolID.Text.Length == 0)
            {

                MessageBox.Show("ID vacio", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else if (!RolBLL.Existe(Convert.ToInt32(TextRolID.Text)))
            {
                Limpiar();
                MessageBox.Show("El registro no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var Rol = RolBLL.Buscar(Convert.ToInt32(TextRolID.Text));
            if (Rol != null)
            {
                Limpiar();
                //this.cliente = cliente;
                this.Rol = Rol;

            }
            else
                Limpiar();


            this.DataContext = this.Rol;
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
            var paso = RolBLL.Guardar(Rol);

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
            if (RolBLL.Eliminar(Convert.ToInt32(TextRolID.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible eliminar el registro", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Limpiar()
        {
            this.Rol = new Roles();
            this.DataContext = Rol;
            Fecha.SelectedDate = DateTime.Now;
        }

        private bool Validar()
        {
            bool esValido = true;
            if (TextRolID.Text.Length == 0)
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
            return esValido;
        }
    }
}

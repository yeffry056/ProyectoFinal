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
    /// Interaction logic for rFrabricante.xaml
    /// </summary>
    public partial class rFrabricante : Window
    {
        private Fabricantes fabricante = new Fabricantes();
        public rFrabricante(List<Usuarios> usuarioInicio)
        {
            InitializeComponent();
            this.DataContext = fabricante;



            UsuarioComboBox.ItemsSource = usuarioInicio.ToArray();
            UsuarioComboBox.SelectedValuePath = "UsuarioId";
            UsuarioComboBox.DisplayMemberPath = "Nombre";


        }
        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = fabricante;

        }
        private void Limpiar()
        {
            this.fabricante = new Fabricantes();
            this.DataContext = fabricante;
        }
        private bool Validar()
        {
            bool esValido = true;
            if (TextFabricanteId.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return esValido;

            }
            if (TextNombre.Text.Length == 0)
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
        private void BtnBuscar(object sender, RoutedEventArgs e)
        {

            var encontrado = FabricanteBLL.Buscar(fabricante.FabricanteId);

            if (encontrado != null)
            {
                fabricante = encontrado;
                Cargar();
                
            }
            else
            {
                Limpiar();
                MessageBox.Show("Venta no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
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
            var paso = FabricanteBLL.Guardar(fabricante);

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
           if(TextFabricanteId.Text.Length == 0)
            {
                MessageBox.Show("FabricanteId vacio", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (FabricanteBLL.Eliminar(Convert.ToInt32(TextFabricanteId.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible eliminar el registro", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
           
        }
    }
}

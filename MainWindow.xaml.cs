using ProyectoFinal.BLL;
using ProyectoFinal.Entidades;
using ProyectoFinal.UI;
using ProyectoFinal.UI.Consultas;
using ProyectoFinal.UI.Registros;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProyectoFinal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            NombreUsuarioTextBox.Focus();
        }
        private void IngresarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = UsuarioBLL.Validar(NombreUsuarioTextBox.Text, ContrasenaPasswordBox.Password);

            if (paso)
            {
                //var usuario = UsuarioBLL.InicioSesion(NombreUsuarioTextBox.Text, ContrasenaPasswordBox.Password);

                rMenu m = new rMenu(UsuarioBLL.InicioSesion(NombreUsuarioTextBox.Text, ContrasenaPasswordBox.Password));
                m.Show();
                this.Close();

            }
            else
            {
                MessageBox.Show("Error Nombre Usuario o Contraseña incorrecta!", "Error!");
                ContrasenaPasswordBox.Clear();
                NombreUsuarioTextBox.Focus();
            }
        }

        private void CancelarButton_Click(object sender, RoutedEventArgs e)
        {

            Application.Current.Shutdown();
        }

        private void enter(object sender, TouchEventArgs e)
        {
            bool paso = UsuarioBLL.Validar(NombreUsuarioTextBox.Text, ContrasenaPasswordBox.Password);

            if (paso)
            {
                //var usuario = UsuarioBLL.InicioSesion(NombreUsuarioTextBox.Text, ContrasenaPasswordBox.Password);

                rMenu m = new rMenu(UsuarioBLL.InicioSesion(NombreUsuarioTextBox.Text, ContrasenaPasswordBox.Password));
                m.Show();
                this.Close();

            }
            else
            {
                MessageBox.Show("Error Nombre Usuario o Contraseña incorrecta!", "Error!");
                ContrasenaPasswordBox.Clear();
                NombreUsuarioTextBox.Focus();
            }
        }

        private void enter(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                bool paso = UsuarioBLL.Validar(NombreUsuarioTextBox.Text, ContrasenaPasswordBox.Password);

                if (paso)
                {
                    //var usuario = UsuarioBLL.InicioSesion(NombreUsuarioTextBox.Text, ContrasenaPasswordBox.Password);

                    rMenu m = new rMenu(UsuarioBLL.InicioSesion(NombreUsuarioTextBox.Text, ContrasenaPasswordBox.Password));
                    m.Show();
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Error Nombre Usuario o Contraseña incorrecta!", "Error!");
                    ContrasenaPasswordBox.Clear();
                    NombreUsuarioTextBox.Focus();
                }
            }
        }

        private void EnterSiguiente(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                ContrasenaPasswordBox.Focus();
            }
        }
    }
}

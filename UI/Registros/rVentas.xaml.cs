﻿using ProyectoFinal.BLL;
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
        public rVentas()
        {
            InitializeComponent();
            this.DataContext = venta;

            ClienteComboBox.ItemsSource = ClienteBLL.GetClientes();
            ClienteComboBox.SelectedValuePath = "ClienteId";
            ClienteComboBox.DisplayMemberPath = "Nombre";

            UsuarioComboBox.ItemsSource = UsuarioBLL.GetListido();
            UsuarioComboBox.SelectedValuePath = "UsuarioId";
            UsuarioComboBox.DisplayMemberPath = "Nombre";

            ArticuloComboBox.ItemsSource = ArticuloBLL.GetListado();
            ArticuloComboBox.SelectedValuePath = "ArticuloId";
            ArticuloComboBox.DisplayMemberPath = "Descripcion";
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
        private void BtnBuscar(object sender, RoutedEventArgs e)
        {

            var encontrado = VentaBLL.Buscar(venta.VentaId);

            if (encontrado != null)
            {
                venta = encontrado;
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
                MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);

            }
        }
    }
}
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Cercos.Extensions;
using Cercos.Services;
using Validation = Cercos.Tools.Validation;

namespace Cercos.Views
{
    public partial class OrdersWindow : Window
    {
        public OrdersWindow()
        {
            InitializeComponent();
            Client.ItemsSource = new ClientsService().GetAllClients();
        }

        private void BtnReturn_OnClick(object sender, RoutedEventArgs e)
        {
            this.Navigate<HomeWindow>();
        }

        private void BtnGuardar_OnClick(object sender, RoutedEventArgs e)
        {
            var clientId = Client.SelectedValue;
            var shapeId = Shape.SelectedValue;

            if (!Validation.ValidateFields(new List<string> { clientId?.ToString(), shapeId?.ToString() }))
            {
                MessageBox.Show("Llene todos los campos");
                return;
            }

            new OrdersService().Insert((int)clientId!, (int)shapeId!);

            Client.SelectedIndex = -1;
            Shape.SelectedIndex = -1;

            MessageBox.Show("Guardado correctamente.");
        }

        private void DataGrid_OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
        }

        private void Shape_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void Client_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var clientId = (int)(Client.SelectedValue ?? 0);
            Shape.ItemsSource = new ShapesService().GetAllFromClient(clientId);
        }
    }
}
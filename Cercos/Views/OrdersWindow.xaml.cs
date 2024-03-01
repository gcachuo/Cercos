using System.Windows;
using System.Windows.Controls;
using Cercos.Extensions;
using Cercos.Services;
using Cercos.ViewModel;

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
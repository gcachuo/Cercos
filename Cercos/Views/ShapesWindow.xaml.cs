using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Cercos.Extensions;
using Cercos.Services;
using Validation = Cercos.Tools.Validation;

namespace Cercos.Views
{
    public partial class ShapesWindow : Window
    {
        public ShapesWindow()
        {
            InitializeComponent();
            Client.ItemsSource = new ClientsService().GetAllClients();
        }

        private void BtnReturn_OnClick(object sender, RoutedEventArgs e)
        {
            this.Navigate<HomeWindow>();
        }

        private void DataGrid_OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
        }

        private void BtnGuardar_OnClick(object sender, RoutedEventArgs e)
        {
            var clientId = Client.SelectedValue;
            var code = Code.Text;
            var name = Name.Text;

            if (!Validation.ValidateFields(new List<string> { clientId?.ToString(), code, name }))
            {
                MessageBox.Show("Llene todos los campos");
                return;
            }

            new ShapesService().Insert((int)clientId!, code, name);

            Client.SelectedIndex = -1;
            Code.Clear();
            Name.Clear();

            MessageBox.Show("Guardado correctamente.");
        }
    }
}
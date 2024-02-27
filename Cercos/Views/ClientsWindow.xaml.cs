using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Cercos.Extensions;
using Cercos.Services;
using Validation = Cercos.Tools.Validation;

namespace Cercos.Views
{
    public partial class ClientsWindow : Window
    {
        public ClientsWindow()
        {
            InitializeComponent();
            DataGrid.ItemsSource = new ClientsService().GetAllClients();
        }

        private void BtnReturn_OnClick(object sender, RoutedEventArgs e)
        {
            this.Navigate<HomeWindow>();
        }

        private void BtnGuardar_OnClick(object sender, RoutedEventArgs e)
        {
            var name = Name.Text;
            var address = Address.Text;
            var phone = Phone.Text;
            var email = Email.Text;

            if (!Validation.ValidateFields(new List<string> { name }))
            {
                MessageBox.Show("Ingrese el nombre");
                return;
            }

            var clientService = new ClientsService();
            clientService.Insert(name, address, phone, email);

            Name.Text = "";
            Address.Text = "";
            Phone.Text = "";
            Email.Text = "";

            MessageBox.Show("Guardado correctamente.");
        }

        private void DataGrid_OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            
        }
    }
}
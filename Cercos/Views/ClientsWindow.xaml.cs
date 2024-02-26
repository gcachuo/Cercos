using System.Collections.Generic;
using System.Windows;
using Cercos.Extensions;
using Cercos.Services;
using Cercos.Tools;

namespace Cercos.Views
{
    public partial class ClientsWindow : Window
    {
        public ClientsWindow()
        {
            InitializeComponent();
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
    }
}
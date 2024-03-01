using System.Windows;
using Cercos.Extensions;
using Cercos.ViewModel;

namespace Cercos.Views
{
    public partial class HomeWindow : Window
    {
        public HomeWindow()
        {
            InitializeComponent();
        }

        private void BtnReturn_OnClick(object sender, RoutedEventArgs e)
        {
            this.Navigate<LoginWindow>();
        }

        private void BtnEmpleadosNuevo_OnClick(object sender, RoutedEventArgs e)
        {
            this.Navigate<UsersWindow>("nuevo");
        }

        private void BtnEmpleados_OnClick(object sender, RoutedEventArgs e)
        {
            this.Navigate<UsersWindow>();
        }

        private void BtnClientesNuevo_OnClick(object sender, RoutedEventArgs e)
        {
            this.Navigate<ClientsWindow>("nuevo");
        }

        private void BtnClientes_OnClick(object sender, RoutedEventArgs e)
        {
            this.Navigate<ClientsWindow>();
        }

        private void BtnEstilosNuevo_OnClick(object sender, RoutedEventArgs e)
        {
            this.Navigate<ShapesWindow>("nuevo");
        }

        private void BtnEstilos_OnClick(object sender, RoutedEventArgs e)
        {
            this.Navigate<ShapesWindow>();
        }
    }
}
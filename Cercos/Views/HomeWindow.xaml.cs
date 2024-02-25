using System.Windows;
using Cercos.Extensions;

namespace Cercos.Views
{
    public partial class HomeWindow : Window
    {
        public HomeWindow()
        {
            InitializeComponent();
        }

        private void BtnEmpleados_OnClick(object sender, RoutedEventArgs e)
        {
            this.Navigate<UsersWindow>();
        }

        private void BtnClientes_OnClick(object sender, RoutedEventArgs e)
        {
            this.Navigate<ClientsWindow>();
        }
    }
}
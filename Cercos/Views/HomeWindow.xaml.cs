using System.Windows;
using Cercos.Extensions;

namespace Cercos.Views
{
    public partial class HomeWindow : Window
    {
        public bool IsAdmin { get; set; }

        public HomeWindow()
        {
            InitializeComponent();
            var sharedViewModel = ((App)Application.Current).SharedViewModel;
            IsAdmin = sharedViewModel.IsAdmin;
            DataContext = this;
        }

        private void BtnEmpleados_OnClick(object sender, RoutedEventArgs e)
        {
            this.Navigate<UsersWindow>();
        }

        private void BtnClientes_OnClick(object sender, RoutedEventArgs e)
        {
            this.Navigate<ClientsWindow>();
        }

        private void BtnReturn_OnClick(object sender, RoutedEventArgs e)
        {
            this.Navigate<LoginWindow>();
        }
    }
}
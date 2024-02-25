using System.Windows;
using Cercos.Extensions;

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
    }
}
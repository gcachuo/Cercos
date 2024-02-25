using System.Windows;
using Cercos.Extensions;

namespace Cercos.Views
{
    public partial class UsersWindow : Window
    {
        public UsersWindow()
        {
            InitializeComponent();
        }

        private void BtnReturn_OnClick(object sender, RoutedEventArgs e)
        {
            this.Navigate<HomeWindow>();
        }
    }
}
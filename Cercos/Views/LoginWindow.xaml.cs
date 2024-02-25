using System;
using System.Windows;
using Cercos.Extensions;
using Cercos.Tools;

namespace Cercos.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow
    {
        private readonly string _hashedPassword;

        public LoginWindow()
        {
            InitializeComponent();

            _hashedPassword = PasswordHasher.HashPassword("admin");
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Login();
        }

        private void Login()
        {
            var password = TxtPassword.Password;

            if (PasswordHasher.VerifyPassword(password, _hashedPassword))
                this.Navigate<HomeWindow>();
            else
                MessageBox.Show("Clave incorrecta");
        }
    }
}
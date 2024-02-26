using System;
using System.Linq;
using System.Windows;
using Cercos.Extensions;
using Cercos.Services;
using Cercos.Tools;

namespace Cercos.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow
    {
        private readonly string _adminPasswordHashed;

        public LoginWindow()
        {
            InitializeComponent();

            _adminPasswordHashed = PasswordHasher.HashPassword("admin");
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Login();
        }

        private void Login()
        {
            var password = TxtPassword.Password;

            if (PasswordHasher.VerifyPassword(password, _adminPasswordHashed))
                this.Navigate<HomeWindow>();
            else if (CheckUserPassword(password))
                this.Navigate<HomeWindow>();
            else
                MessageBox.Show("Clave incorrecta");
        }

        private static bool CheckUserPassword(string password)
        {
            var users = UsersService.GetAllUsers();
            return users.Any(user => PasswordHasher.VerifyPassword(password, user.Password));
        }
    }
}
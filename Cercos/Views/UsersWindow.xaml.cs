using System.Collections.Generic;
using System.Windows;
using Cercos.Extensions;
using Cercos.Services;
using Cercos.Tools;

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

        private void BtnGuardar_OnClick(object sender, RoutedEventArgs e)
        {
            var fullname = FullName.Text;
            var password = Password.Text;

            if (!Validation.ValidateFields(new List<string> { fullname, password }))
            {
                MessageBox.Show("Llene todos los campos");
                return;
            }

            if (UsersService.CheckDuplicates(password))
            {
                MessageBox.Show("Eliga otra clave.");
                return;
            }

            var passwordHashed = PasswordHasher.HashPassword(password);
            
            UsersService.Insert(fullname, passwordHashed);

            FullName.Text = "";
            Password.Text = "";

            MessageBox.Show("Guardado correctamente.");
        }
    }
}
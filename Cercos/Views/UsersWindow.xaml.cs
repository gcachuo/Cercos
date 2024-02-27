using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Cercos.Extensions;
using Cercos.Services;
using Cercos.Tools;
using Validation = Cercos.Tools.Validation;

namespace Cercos.Views
{
    public partial class UsersWindow : Window
    {
        public UsersWindow()
        {
            InitializeComponent();
            DataGrid.ItemsSource = UsersService.GetAllUsers();
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

        private void DataGrid_OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Password")
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
        }
    }
}
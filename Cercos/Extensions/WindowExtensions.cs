using System.Windows;
using Cercos.ViewModel;

namespace Cercos.Extensions
{
    public static class WindowExtensions
    {
        private static readonly SharedViewModel ViewModel = ((App)Application.Current).SharedViewModel;

        public static void Navigate<T>(this Window currentWindow) where T : Window, new()
        {
            ViewModel.Action = null;
            var window = new T
            {
                WindowState = WindowState.Maximized,
                ResizeMode = ResizeMode.NoResize,
                Width = SystemParameters.PrimaryScreenWidth,
                Height = SystemParameters.PrimaryScreenHeight,
                DataContext = ViewModel
            };
            window.Show();
            currentWindow.Close();
        }

        public static void Navigate<T>(this Window currentWindow, string action) where T : Window, new()
        {
            ViewModel.Action = action;
            var window = new T
            {
                WindowState = WindowState.Maximized,
                ResizeMode = ResizeMode.NoResize,
                Width = SystemParameters.PrimaryScreenWidth,
                Height = SystemParameters.PrimaryScreenHeight,
                DataContext = ViewModel
            };
            window.Show();
            currentWindow.Close();
        }
    }
}
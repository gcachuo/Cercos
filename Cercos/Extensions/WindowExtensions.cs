using System.Windows;

namespace Cercos.Extensions
{
    public static class WindowExtensions
    {
        public static void Navigate<T>(this Window currentWindow) where T : Window, new()
        {
            var window = new T
            {
                WindowState = WindowState.Maximized,
                ResizeMode = ResizeMode.NoResize,
                Width = SystemParameters.PrimaryScreenWidth,
                Height = SystemParameters.PrimaryScreenHeight
            };
            window.DataContext = ((App)Application.Current).SharedViewModel;
            window.Show();
            currentWindow.Close();
        }
    }
}
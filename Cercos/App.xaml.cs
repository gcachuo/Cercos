using Cercos.ViewModel;

namespace Cercos
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public SharedViewModel SharedViewModel { get; } = new SharedViewModel();
    }
}
using System.Windows;
using TestPOSAdapter.ViewModel;

namespace TestPOSAdapter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new POSAdapterViewModel();
        }
    }
}

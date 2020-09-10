using System.Windows.Input;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace FolderApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView : Xamarin.Forms.MasterDetailPage
    {
        public MainView()
        {
            On<iOS>().SetApplyShadow(true);
            InitializeComponent();
        }

        public MainView(ICommand restore)
        {
            On<iOS>().SetApplyShadow(true);
        }
    }
}
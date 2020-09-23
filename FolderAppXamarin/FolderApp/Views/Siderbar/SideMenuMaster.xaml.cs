using FolderApp.ViewModel.SideMenu;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FolderApp.Views.SideMenu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SideMenuMaster : ContentPage
    {
        SideMenuMasterVM viewModel;

        public SideMenuMaster()
        {

            InitializeComponent();

            viewModel = new SideMenuMasterVM();

            BindingContext = viewModel;
        }
    }

}
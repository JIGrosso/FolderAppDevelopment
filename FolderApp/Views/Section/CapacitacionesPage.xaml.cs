using FolderApp.ViewModel.Section;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FolderApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CapacitacionesPage : ContentPage
    {
        CapacitacionesVM viewModel;

        public CapacitacionesPage()
        {
            ((App.Current.MainPage as MasterDetailPage).Detail as NavigationPage).BarBackgroundColor = Color.FromHex("#27818E");

            InitializeComponent();

            viewModel = new CapacitacionesVM();
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.UpdatePosts();
        }
    }
}
using FolderApp.ViewModel.Secciones;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FolderApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProduccionPage : ContentPage
    {

        ProduccionVM viewModel;

        public ProduccionPage()
        {
            ((App.Current.MainPage as MasterDetailPage).Detail as NavigationPage).BarBackgroundColor = Color.FromHex("#F6B109");

            InitializeComponent();

            viewModel = new ProduccionVM();
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.UpdatePosts();
        }
    }
}
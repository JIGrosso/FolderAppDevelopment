using FolderApp.ViewModel.Secciones;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FolderApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RRHHPage : ContentPage
    {
        RrhhVM viewModel;

        public RRHHPage()
        {
            ((App.Current.MainPage as MasterDetailPage).Detail as NavigationPage).BarBackgroundColor = Color.FromHex("#6F1850");

            InitializeComponent();

            viewModel = new RrhhVM();
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.UpdatePosts();
        }
    }
}
using FolderApp.ViewModel.Secciones;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FolderApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SocialPage : ContentPage
    {

        SocialVM viewModel;

        public SocialPage()
        {
            ((App.Current.MainPage as MasterDetailPage).Detail as NavigationPage).BarBackgroundColor = Color.FromHex("#51AC4F");

            InitializeComponent();

            viewModel = new SocialVM();
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.UpdatePosts();
        }
    }
}
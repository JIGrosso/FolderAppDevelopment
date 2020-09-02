using FolderApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FolderApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoticiasPage : ContentPage
    {
        NoticiasVM viewModel;

        public NoticiasPage()
        {
            InitializeComponent();

            viewModel = new NoticiasVM();
            BindingContext = viewModel;
            viewModel.UpdatePostsGeneric();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((App.Current.MainPage as MasterDetailPage).Detail as NavigationPage).BarBackgroundColor = Color.FromHex("#6F1850");
        }
    }
}
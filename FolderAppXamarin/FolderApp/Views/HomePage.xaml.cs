using FolderApp.Common.Enum;
using FolderApp.ViewModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FolderApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {

        HomeVM viewModel;

        public HomePage()
        {
            InitializeComponent();

            viewModel = new HomeVM();
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((App.Current.MainPage as MasterDetailPage).Detail as NavigationPage).BarBackgroundColor = SectionColorEnum.Noticias;
            Task.Run(() => viewModel.GetActivities());

        }
    }
}
using FolderApp.Common.Enum;
using FolderApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FolderApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            BindingContext = new HomeVM();
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((App.Current.MainPage as MasterDetailPage).Detail as NavigationPage).BarBackgroundColor = SectionColorEnum.Noticias;
        }
    }
}
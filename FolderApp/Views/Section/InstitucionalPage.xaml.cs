using FolderApp.Common;
using FolderApp.ViewModel.Section;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FolderApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InstitucionalPage : ContentPage
    {
        SectionVM viewModel;

        public InstitucionalPage()
        {
            ((App.Current.MainPage as MasterDetailPage).Detail as NavigationPage).BarBackgroundColor = Color.FromHex("#B20207");

            InitializeComponent();

            viewModel = new SectionVM(CategoriesEnum.Direccion);
            BindingContext = viewModel;

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.UpdatePosts();
        }

    }
}
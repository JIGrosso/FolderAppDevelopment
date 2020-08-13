using FolderApp.Common;
using FolderApp.ViewModel.Section;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FolderApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SectionPage : ContentPage
    {
        SectionVM viewModel;

        public SectionPage(CategoriesEnum category)
        {
            InitializeComponent();

            viewModel = new SectionVM(category);
            BindingContext = viewModel;
            ((App.Current.MainPage as MasterDetailPage).Detail as NavigationPage).BarBackgroundColor = viewModel.TitleBackgroundColor;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.UpdatePosts();

        }

        private void listView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            viewModel.Expand(e.Item);
        }
    }
}
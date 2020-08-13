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
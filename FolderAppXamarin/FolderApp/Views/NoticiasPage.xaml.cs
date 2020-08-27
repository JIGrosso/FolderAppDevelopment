using FolderApp.Model;
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
            viewModel.UpdatePosts();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((App.Current.MainPage as MasterDetailPage).Detail as NavigationPage).BarBackgroundColor = Color.FromHex("#6F1850");
        }

        private void listView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            viewModel.Expand(e.Item);
        }

        private void listView_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            var post = e.Item as Post;
            if(post.Index == viewModel.Posts.Count - 1 && !viewModel.ActivityIndicatorVisible)
            {
                viewModel.UpdatePosts(page: viewModel.CurrentPage + 1);
            }
        }
    }
}
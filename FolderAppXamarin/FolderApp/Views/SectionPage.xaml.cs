using FolderApp.Common;
using FolderApp.Model;
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
            viewModel.UpdatePosts();
        }

        private void listView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            viewModel.Expand(e.Item);
        }

        private void listView_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            var post = e.Item as Post;
            if (post.Index == viewModel.Posts.Count - 1 && !viewModel.ActivityIndicatorVisible)
            {
                viewModel.UpdatePosts(page: viewModel.CurrentPage + 1);
            }
        }
    }
}
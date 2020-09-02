using FolderApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FolderApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostList : ContentView
    {

        public PostList()
        {
            InitializeComponent();
        }

        void OnCollectionViewScrolled(object sender, ItemsViewScrolledEventArgs e)
        {
            (BindingContext as PostListVM).ScrolledDown = e.VerticalDelta > 0;
        }
    }
}
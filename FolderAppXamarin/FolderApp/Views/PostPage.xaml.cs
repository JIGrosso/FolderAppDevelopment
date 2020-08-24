using FolderApp.Model;
using FolderApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FolderApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostPage : ContentPage
    {
        PostVM viewModel;

        public PostPage()
        {
            InitializeComponent();
        }
        public PostPage(Post selectedPost)
        {
            InitializeComponent();

            //TODO: Por ahora muestra bien el elemento con ese BindingContext, pero lo ideal sería utilizar el viewModel con el id del post a mostrar.
            //Traerlo desde la BD, y asignar las propiedades al VM, de esta forma se pueden manejar los cambios en los comentarios.

            viewModel = new PostVM(selectedPost);
            BindingContext = viewModel;
        }
    }
}
using FolderApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FolderApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoticiasPage : ContentPage
    {
        Post post;

        public NoticiasPage()
        {
            InitializeComponent();

            post = new Post();
            BindingContext = post;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var post = new Post();
            post.Title = "Lanzamiento a producción de la App B2K – Gestya para Brasil";
            post.PostedDate = DateTime.Today;
            post.Section = "RRHHPage";

            var post2 = new Post();
            post2.Title = "Titulo de prueba";
            post2.PostedDate = DateTime.Today;
            post2.Section = "RRHHPage";

            List<Post> posts = new List<Post>();
            posts.Add(post);
            posts.Add(post2);


            listView.ItemsSource = posts;


            
        }
    }
}
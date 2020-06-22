using FolderApp.Model;
using FolderApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace FolderApp.ViewModel
{
    class NoticiasVM
    {
        public ObservableCollection<Post> Posts { get; set; }

        public NoticiasVM ()
        {
            Posts = new ObservableCollection<Post>();
        }

        public async void UpdatePosts()
        {
            ((App.Current.MainPage as MasterDetailPage).Detail as NavigationPage).BarBackgroundColor = Color.FromHex("#6F1850");

            List<Post> posts = new List<Post>();

            posts = await Post.UpdatePosts();

            //Provisional

            var post = new Post();
            post.Title = "Lanzamiento a producción de la App B2K – Gestya para Brasil";
            post.PostedDate = DateTime.Today;
            post.Section = "RRHHPage";
            post.PostImage = new Image
            {
                Source = ImageSource.FromUri(
                    new Uri("https://upload.wikimedia.org/wikipedia/commons/thumb/f/fc/Papio_anubis_%28Serengeti%2C_2009%29.jpg/200px-Papio_anubis_%28Serengeti%2C_2009%29.jpg"))
            };

            var post2 = new Post();
            post2.Title = "Titulo de prueba";
            post2.PostedDate = DateTime.Today;
            post2.Section = "RRHHPage";

            posts.Add(post);
            posts.Add(post2);

            //Agrego a la ObservableCollection

            if(posts != null)
            {
                Posts.Clear();
                foreach (var x in posts)
                {
                    Posts.Add(x);
                }
            }
            else // == null => Error
            {
                //Vuelva a intentarlo
            }
        }

        public void Expand(object item)
        {
            (App.Current.MainPage as MasterDetailPage).Detail.Navigation.PushAsync(new PostPage(item as Post));
        }
    }
}

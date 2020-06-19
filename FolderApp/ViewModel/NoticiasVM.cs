using FolderApp.Model;
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

        public void UpdatePosts()
        {
            ((App.Current.MainPage as MasterDetailPage).Detail as NavigationPage).BarBackgroundColor = Color.FromHex("#6F1850");

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

            List<Post> posts = new List<Post>();
            posts.Add(post);
            posts.Add(post2);

            if(posts != null)
            {
                Posts.Clear();
                foreach (var x in posts)
                {
                    Posts.Add(x);
                }
            }
        }
        
    }
}

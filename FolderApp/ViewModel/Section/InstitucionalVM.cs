using FolderApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace FolderApp.ViewModel.Secciones
{
    class InstitucionalVM
    {
        public ObservableCollection<Post> PostsInstitucionales { get; set; }

        public InstitucionalVM()
        {
            PostsInstitucionales = new ObservableCollection<Post>();
        }

        public void UpdatePostsInstitucionales()
        {
            var post = new Post();
            post.Title = "Covid-19 Coronavirus. Protegete, protegé.";
            post.PostedDate = DateTime.Today;
            post.Section = "Institucional";
            post.PostImage = new Image
            {
                Source = ImageSource.FromUri(
                    new Uri("https://upload.wikimedia.org/wikipedia/commons/thumb/f/fc/Papio_anubis_%28Serengeti%2C_2009%29.jpg/200px-Papio_anubis_%28Serengeti%2C_2009%29.jpg"))
            };


            List<Post> posts = new List<Post>();
            posts.Add(post);

            if (posts != null)
            {
                PostsInstitucionales.Clear();
                foreach (var x in posts)
                {
                    PostsInstitucionales.Add(x);
                }
            }
        }
    }
}

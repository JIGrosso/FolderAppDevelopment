using FolderApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace FolderApp.ViewModel.Section
{
    class CapacitacionesVM
    {
        public ObservableCollection<Post> PostsCapacitaciones { get; set; }

        public CapacitacionesVM()
        {
            PostsCapacitaciones = new ObservableCollection<Post>();
        }

        public void UpdatePostsCapacitaciones()
        {
            var post = new Post();
            post.Title = "Renovamos Nuestro Blog Técnico";
            post.PostedDate = DateTime.Today;
            post.Section = "Capacitaciones";
            post.PostImage = new Image
            {
                Source = ImageSource.FromUri(
                    new Uri("https://upload.wikimedia.org/wikipedia/commons/thumb/f/fc/Papio_anubis_%28Serengeti%2C_2009%29.jpg/200px-Papio_anubis_%28Serengeti%2C_2009%29.jpg"))
            };


            List<Post> posts = new List<Post>();
            posts.Add(post);

            if (posts != null)
            {
                PostsCapacitaciones.Clear();
                foreach (var x in posts)
                {
                    PostsCapacitaciones.Add(x);
                }
            }

        }
    }
}

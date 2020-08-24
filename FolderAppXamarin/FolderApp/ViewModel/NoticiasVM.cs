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

            List<Post> posts = await Post.UpdatePosts();

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

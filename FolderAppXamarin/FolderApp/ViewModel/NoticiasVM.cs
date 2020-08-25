using FolderApp.Model;
using FolderApp.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace FolderApp.ViewModel
{
    class NoticiasVM : INotifyPropertyChanged
    {
        public ObservableCollection<Post> Posts { get; set; }

        private bool activityInticatorVisible = true;
        public bool ActivityIndicatorVisible
        {
            get
            {
                return activityInticatorVisible;
            }
            set
            {
                activityInticatorVisible = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(ActivityIndicatorVisible)));
            }
        }

        public NoticiasVM ()
        {
            Posts = new ObservableCollection<Post>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public async void UpdatePosts()
        {
            ((App.Current.MainPage as MasterDetailPage).Detail as NavigationPage).BarBackgroundColor = Color.FromHex("#6F1850");

            List<Post> posts = await Post.UpdatePosts();

            ActivityIndicatorVisible = false;

            //Agrego a la ObservableCollection

            if (posts != null)
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

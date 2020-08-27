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
        public int CurrentPage { get; set; } = 0;

        public ObservableCollection<Post> Posts { get; set; } = new ObservableCollection<Post>();

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

        public event PropertyChangedEventHandler PropertyChanged;

        public async void UpdatePosts(int page = 1)
        {
            if(page > CurrentPage)
            {
                CurrentPage = page;

                ActivityIndicatorVisible = true;

                List<Post> posts = await Post.GetPosts(page: page, prevCount: Posts.Count);

                ActivityIndicatorVisible = false;

                //Agrego a la ObservableCollection

                if (posts != null)
                {
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
        }

        public void Expand(object item)
        {
            (App.Current.MainPage as MasterDetailPage).Detail.Navigation.PushAsync(new PostPage(item as Post));
        }
    }
}

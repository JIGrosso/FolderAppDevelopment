using FolderApp.Common;
using FolderApp.Model;
using FolderApp.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FolderApp.ViewModel
{
    abstract class PostListVM : INotifyPropertyChanged
    {
        public ObservableCollection<Post> Posts { get; set; } = new ObservableCollection<Post>();

        public int CurrentPage { get; set; } = 0;

        private Post selectedItem { get; set; }
        public Post SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedItem)));
            }
        }

        public bool ScrolledDown = true;

        private bool isRefreshing = true;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsRefreshing
        {
            get
            {
                return isRefreshing;
            }
            set
            {
                isRefreshing = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(IsRefreshing)));
            }
        }

        public void Expand(object item)
        {
            (App.Current.MainPage as MasterDetailPage).Detail.Navigation.PushAsync(new PostPage(item as Post));
        }

        public ICommand ItemTapped
        {
            get
            {
                return new Command(_ =>
                {
                    if (SelectedItem == null)
                        return;

                    Expand(SelectedItem);
                    SelectedItem = null;
                });
            }
        }

        public ICommand LoadMorePostsCommand
        {
            get
            {
                return new Command(_ =>
                {
                    if (!IsRefreshing)
                        UpdatePostsGeneric(page: CurrentPage + 1);
                });
            }
        }

        public ICommand RefreshCommand
        {
            get
            {
                return new Command(_ =>
                {
                    if (!ScrolledDown)
                    {
                        UpdatePostsGeneric(page: 1, deletePrevious: true);
                    }
                });
            }
        }

        protected async Task UpdatePosts(int page = 1, bool deletePrevious = false, CategoriesEnum? category = null)
        {
            IsRefreshing = true;

            if (deletePrevious)
            {
                ScrolledDown = false;

                Posts.Clear();
            }

            else
            {
                if (page <= CurrentPage)
                {
                    return;
                }
            }

            CurrentPage = page;

            List<Post> posts;

            if ((int)category > 0)
            {
                posts = await Post.GetPosts(sectionId: (int)category, page: 1, prevCount: Posts.Count);
            }
            else
            {
                posts = await Post.GetPosts(page: 1, prevCount: Posts.Count);
            }

            IsRefreshing = false;

            foreach (var x in posts)
            {
                Posts.Add(x);
            }

        }

        public abstract void UpdatePostsGeneric(int page = 1, bool deletePrevious = false, CategoriesEnum? category = null);
    }
}

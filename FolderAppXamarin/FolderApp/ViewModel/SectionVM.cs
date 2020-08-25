using FolderApp.Common;
using FolderApp.Model;
using FolderApp.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace FolderApp.ViewModel.Section
{
    class SectionVM : INotifyPropertyChanged
    {
        public CategoriesEnum Category;

        public event PropertyChangedEventHandler PropertyChanged;

        public Color TitleBackgroundColor { get; set; }

        public string TitleText { get; set; }

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

        public SectionVM(CategoriesEnum category)
        {
            Posts = new ObservableCollection<Post>();
            Category = category;
            TitleBackgroundColor = SectionParameters.GetSectionColor(category);
            TitleText = SectionParameters.GetSectionTitle(category);
        }

        public async void UpdatePosts()
        {
            List<Post> posts = await Post.UpdatePostBySection((int)Category);

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

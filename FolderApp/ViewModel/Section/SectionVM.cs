using FolderApp.Common;
using FolderApp.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FolderApp.ViewModel.Section
{
    class SectionVM
    {
        public CategoriesEnum Category;

        public ObservableCollection<Post> Posts { get; set; }

        public SectionVM(CategoriesEnum category)
        {
            Posts = new ObservableCollection<Post>();
            Category = category;
        }

        public async void UpdatePosts()
        {
            List<Post> posts = await Post.UpdatePostBySection((int)Category);

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
    }
}

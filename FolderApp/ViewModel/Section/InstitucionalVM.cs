using FolderApp.Common;
using FolderApp.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace FolderApp.ViewModel.Secciones
{
    class InstitucionalVM
    {
        public ObservableCollection<Post> Posts { get; set; }

        public InstitucionalVM()
        {
            Posts = new ObservableCollection<Post>();
        }

        public async void UpdatePosts()
        {
            ((App.Current.MainPage as MasterDetailPage).Detail as NavigationPage).BarBackgroundColor = Color.FromHex("#6F1850");

            List<Post> posts = new List<Post>();

            posts = await Post.UpdatePostBySection((int)CategoriesEnum.Direccion);

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

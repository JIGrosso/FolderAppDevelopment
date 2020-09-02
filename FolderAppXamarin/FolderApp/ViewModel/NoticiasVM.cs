using FolderApp.Common;
using System.ComponentModel;

namespace FolderApp.ViewModel
{
    class NoticiasVM : PostListVM, INotifyPropertyChanged
    {

        public override async void UpdatePostsGeneric(int page = 1, bool deletePrevious = false, CategoriesEnum? category = null)
        {
            await UpdatePosts(page, deletePrevious);
        }
    }
}

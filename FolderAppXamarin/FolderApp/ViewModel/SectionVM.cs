using FolderApp.Common;
using FolderApp.Model;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace FolderApp.ViewModel.Section
{
    class SectionVM : PostListVM
    {
        public CategoriesEnum Category;

        public Color TitleBackgroundColor { get; set; }

        public string TitleText { get; set; }

        public SectionVM(CategoriesEnum category)
        {
            Posts = new ObservableCollection<Post>();
            Category = category;
            TitleBackgroundColor = SectionParameters.GetSectionColor(category);
            TitleText = SectionParameters.GetSectionTitle(category);
        }

        public override async void UpdatePostsGeneric(int page = 1, bool deletePrevious = false, CategoriesEnum? category = null)
        {
            await UpdatePosts(page, deletePrevious, Category);
        }
    }
}

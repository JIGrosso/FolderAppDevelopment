using FolderApp.Common;
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
            Category = category;
            TitleBackgroundColor = SectionParameters.GetSectionColor(category);
            TitleText = SectionParameters.GetSectionTitle(category);
        }

        public override async void UpdatePostsGeneric(int page = 1, bool deletePrevious = false, CategoriesEnum? category = null, string query = null)
        {
            await UpdatePosts(page, deletePrevious, Category, query);
        }

        internal void OnSearchButtonPressed()
        {
            IsQueryList = true;
            UpdatePostsGeneric(page: 1, deletePrevious: true, query: Filter);
        }

        internal void OnTextChanged()
        {
            if (string.IsNullOrEmpty(Filter))
            {
                IsQueryList = false;
                QueryPosts.Clear();
            }
        }
    }
}

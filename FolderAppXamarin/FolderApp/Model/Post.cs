using ExtensionMethods;
using FolderApp.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WordPressPCL.Utility;
using Xamarin.Forms;

namespace FolderApp.Model
{
    public class Post
    {
        public int Index { get; set; }

        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime PostedDate { get; set; }

        public string Section { get; set; }

        public string Content { get; set; }

        public Image PostImage { get; set; }

        public bool IsSectionNotNull
        {
            get { return Section != null && Section != ""; }
        }

        public bool IsImageNotNull
        {
            get { return PostImage != null; }
        }

        public static async Task<List<Post>> GetPosts(int? sectionId = null, int page = 1, int prevCount = 0)
        {
            try
            {
                List<Post> returningPosts = new List<Post>();

                var queryBuilder = new PostsQueryBuilder();
                queryBuilder.PerPage = 7;
                queryBuilder.Page = page;
                if (sectionId != null)
                {
                    queryBuilder.Categories = new int[] { (int)sectionId };
                }
                var posts = await App.client.Posts.Query(queryBuilder);

                returningPosts = await ListPosts(posts, prevCount);

                return returningPosts;

            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
                return null;
            }
        }

        private static async Task<List<Post>> ListPosts(IEnumerable<WordPressPCL.Models.Post> posts, int prevCount)
        {
            var returningPosts = new List<Post>();

            foreach (var aux in posts)
            {
                Image image = null;
                if (aux.FeaturedMedia != null && aux.FeaturedMedia != 0)
                {
                    var media = await App.client.Media.GetByID(aux.FeaturedMedia, true, true);
                    image = new Image
                    {
                        Source = ImageSource.FromUri(new Uri(media.SourceUrl))
                    };
                }

                returningPosts.Add(new Post()
                {
                    Index = prevCount + returningPosts.Count,
                    Id = aux.Id,
                    Title = aux.Title.Rendered.RemoveHtml(),
                    Content = aux.Content.Rendered,
                    PostedDate = aux.Date,
                    PostImage = image,
                    Section = ((CategoriesEnum)aux.Categories[0]).GetDescription()
                });
            }

            return returningPosts;
        }
    }
}

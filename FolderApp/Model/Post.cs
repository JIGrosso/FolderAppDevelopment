using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FolderApp.Model
{
    public class Post
    {
        private string title;

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
            }
        }

        private DateTime postedDate;

        public DateTime PostedDate
        {
            get { return postedDate; }
            set
            {
                postedDate = value;
            }
        }

        private string section;

        public string Section
        {
            get { return section; }
            set
            {
                section = value;
            }
        }

        private string content;

        public string Content
        {
            get { return content; }
            set
            {
                content = value;
            }
        }

        private Image postImage;

        public Image PostImage
        {
            get { return postImage; }
            set
            {
                postImage = value;
            }
        }

        public bool IsImageNotNull
        {
            get { return PostImage != null; }
        }


        public static async Task<List<Post>> UpdatePosts()
        {
            try
            {
                List<Post> returningPosts = new List<Post>();

                var posts = await App.client.Posts.GetAll();

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
                        Title = aux.Title.Rendered,
                        Content = aux.Content.Rendered,
                        PostedDate = aux.Date,
                        PostImage = image
                        //Section = aux.Categories[0].ToString() //TODO: revisar asignación de sección
                    });

                }

                return returningPosts;

            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
                return null;
            }
        }

    }
}

using FolderApp.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FolderApp.Model
{
    public class Comment
    {
        public string Content { get; set; }

        public DateTime CommentDate { get; set; }

        public string IdAuthor { get; set; }

        public Image ProfileIcon { get; set; }

        public string AuthorName { get; set; }

        internal static async Task<List<Comment>> GetCommentsForPost(int postId)
        {
            var comments = new List<Comment>();
            var clientComments = await App.client.Comments.GetCommentsForPost(postId);
            foreach (WordPressPCL.Models.Comment comment in clientComments)
            {
                Image image;
                if(comment.AuthorAvatarUrls.Size48 != null && !comment.AuthorAvatarUrls.Size48.Contains("gravatar"))
                {
                    image = new Image()
                    {
                        Source = ImageSource.FromUri(new Uri(comment.AuthorAvatarUrls.Size48))
                    };
                } else
                {
                    var urlString = ("https://ui-avatars.com/api/?name=" + comment.AuthorName +
                        "&background=6f1850" +
                        "&rounded=true" +
                        "&color=FFFFFF").Replace(' ', '+');
                    image = new Image()
                    {
                        Source = ImageSource.FromUri(new Uri(urlString))
                    };
                }

                comments.Add(new Comment
                {
                    AuthorName = comment.AuthorName,
                    CommentDate = comment.Date,
                    Content = StringHelper.RemoveHtml(comment.Content.Rendered),
                    ProfileIcon = image
                });
            }
            return comments;
        }
    }
}

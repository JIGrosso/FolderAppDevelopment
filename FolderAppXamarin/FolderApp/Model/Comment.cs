using static ExtensionMethods.MyExtensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

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
                var image = GetAvatarOrDefault(comment.AuthorAvatarUrls.Size48, comment.AuthorName);

                comments.Add(new Comment
                {
                    AuthorName = comment.AuthorName,
                    CommentDate = comment.Date,
                    Content = comment.Content.Rendered.RemoveHtml(),
                    ProfileIcon = image
                });
            }
            return comments;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace FolderApp.Model
{
    public class Comment
    {
        private string content;

        public string Content
        {
            get { return content; }
            set
            {
                content = value;
            }
        }

        private DateTime commentDate;

        public DateTime CommentDate
        {
            get { return commentDate; }
            set
            {
                commentDate = value;
            }
        }

        //Identifies an user
        private string idAuthor;    

        public string IdAuthor
        {
            get { return idAuthor; }
            set
            {
                idAuthor = value;
            }
        }

        private string authorName;

        public string AuthorName
        {
            get { return authorName; }
            set
            {
                authorName = value;
            }
        }

        internal static async Task<List<Comment>> GetCommentsForPost(int postId)
        {
            var comments = new List<Comment>();
            var clientComments = await App.client.Comments.GetCommentsForPost(postId);
            foreach (WordPressPCL.Models.Comment comment in clientComments)
            {
                comments.Add(new Comment
                {
                    AuthorName = comment.AuthorName,
                    CommentDate = comment.Date,
                    Content = comment.Content.Rendered,
                });
            }
            return comments;
        }
    }
}

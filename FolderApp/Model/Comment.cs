using System;
using System.Collections.Generic;
using System.Text;

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




    }
}

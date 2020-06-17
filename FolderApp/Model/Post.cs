using System;
using System.Collections.Generic;
using System.Text;

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


    }
}

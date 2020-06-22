using FolderApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FolderApp.ViewModel
{
    public class PostVM : INotifyPropertyChanged
    {

        private Post post;

        public Post Post
        {
            get { return post; }
            set
            {
                post = value;           
            }
        }


        private string title;

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }

        private string section;

        public string Section
        {
            get { return section; }
            set
            {
                section = value;
                OnPropertyChanged("Section");
            }            
        }

        private string content;

        public string Content
        {
            get { return content; }
            set
            {
                content = value;
                OnPropertyChanged("Content");
            }
        }

        private DateTime postedDate;

        public DateTime PostedDate      
        {
            get { return postedDate; }
            set
            {
                postedDate = value;
                OnPropertyChanged("PostedDate");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


    }
}

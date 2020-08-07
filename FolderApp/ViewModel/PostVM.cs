using FolderApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using WordPressPCL.Client;
using Xamarin.Forms;

namespace FolderApp.ViewModel
{
    public class PostVM : INotifyPropertyChanged
    {
        public int ListHeight { get; set; }

        public ObservableCollection<Comment> CommentsList { get; set; }

        public PostVM()
        {
            CommentsList = new ObservableCollection<Comment>();
        }

        public PostVM(Post selectedPost)
        {
            Post = selectedPost;

            CommentsList = new ObservableCollection<Comment>();

            ReadComments(selectedPost.Id);
        }



        private Post post;

        public Post Post
        {
            get { return post; }
            set
            {
                post = value;
                Title = post.Title;
                Content = post.Content;
                Section = post.Section;
                PostedDate = post.PostedDate;
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

        public static void ReadPost(string id)
        {
            //Buscar post en BD
        }

        public async void ReadComments(int postId)
        {
            var comments = await Comment.GetCommentsForPost(postId);
            foreach (Comment comment in comments)
            {
                CommentsList.Add(comment);
            }
            ListHeight = (CommentsList.Count * 70) + (CommentsList.Count * 10);
            OnPropertyChanged("ListHeight");
        }
    }
}

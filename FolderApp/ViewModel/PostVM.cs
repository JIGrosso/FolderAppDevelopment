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

        public ObservableCollection<Comment> CommentsList { get; set; }

        int count;

        public PostVM ()
        {
            CommentsList = new ObservableCollection<Comment>();
        }

        public PostVM(Post selectedPost)
        {
            CommentsList = new ObservableCollection<Comment>();

            Post = selectedPost;

            ReadComments(selectedPost.Title);

            Height = CommentsList.Count * 60;

            ChangeListViewSizeCommand = new Command(ChangeListViewSize);
        }

        private int height;

        public int Height
        {
            get { return height; }
            set
            {
                height = value;
                OnPropertyChanged("Height");
            }
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

        public void ReadComments(string postId)
        {
            //client.Comments.GetCommentsFor Post(postId)
            var c1 = new Comment();
            c1.AuthorName = "Juani";
            c1.Content = "Comentario de prueba";
            c1.CommentDate = DateTime.Today;

            var c2 = new Comment();
            c2.AuthorName = "Juani";
            c2.Content = "Comentario de prueba";
            c2.CommentDate = DateTime.Today;

            var c3 = new Comment();
            c3.AuthorName = "Juani";
            c3.Content = "Comentario de prueba";
            c3.CommentDate = DateTime.Today;

            var c4 = new Comment();
            c4.AuthorName = "Juani";
            c4.Content = "Comentario de prueba";
            c4.CommentDate = DateTime.Today;

            CommentsList.Add(c1);
            CommentsList.Add(c2);
            CommentsList.Add(c3);
            CommentsList.Add(c4);

        }

        public ICommand ChangeListViewSizeCommand { get; }

        void ChangeListViewSize()
        {
            count = CommentsList.Count + 1;
            //CommentsList.Add(new Comment() {});
            Height = (CommentsList.Count * 40);
            //(CommentsList.Count * 10)
        }
    }
}

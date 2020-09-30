using FolderApp.Model;
using System;
using System.Collections.ObjectModel;

namespace FolderApp.ViewModel
{
    public class PostVM
    {

        public ObservableCollection<Comment> CommentsList { get; set; }

        public string CommentText { get; set; }

        public PostVM()
        {
            CommentsList = new ObservableCollection<Comment>();
        }

        public PostVM(Post selectedPost)
        {
            Post = selectedPost;

            CommentsList = new ObservableCollection<Comment>();

            ReadComments(Post.Id);
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

        public string Title { get; set; }

        public string Section { get; set; }

        public async void OnCommentPressed()
        {
            if (string.IsNullOrEmpty(CommentText))
            {
                return;
            }
            if(await Comment.PushComment(Post.Id, CommentText))
            {
                CommentText = string.Empty;
                ReadComments(Post.Id);
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Ocurrió un error al crear el comentario, por favor intente nuevamente", "Ok");
            }
        }

        public string Content { get; set; }

        public DateTime PostedDate { get; set; }

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
        }
    }
}

﻿using System;
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


        public static async Task<List<Post>> UpdatePosts()
        {
            try
            {
                List<Post> returningPosts = new List<Post>();

                var posts = await App.client.Posts.GetAll();

                foreach(var aux in posts)
                {
                    //Obtengo todos los datos del post y los agrego a returningPosts

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

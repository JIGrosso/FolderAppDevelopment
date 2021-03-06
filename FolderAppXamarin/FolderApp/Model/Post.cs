﻿using ExtensionMethods;
using FolderApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordPressPCL.Models;
using WordPressPCL.Utility;
using Xamarin.Forms;

namespace FolderApp.Model
{
    public class Post
    {
        public int Index { get; set; }

        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime PostedDate { get; set; }

        public string Section { get; set; }

        public string Content { get; set; }

        public Image PostImage { get; set; }

        public bool IsSectionNotNull
        {
            get { return Section != null && Section != ""; }
        }

        public bool IsImageNotNull
        {
            get { return PostImage != null; }
        }

        public int DateRow { 
            get
            {
                return IsSectionNotNull ? 2 : 1;
            } 
        }

        public static async Task<List<Post>> GetPosts(int? sectionId = null, int page = 1, int prevCount = 0, string query = null)
        {
            try
            {
                List<Post> returningPosts = new List<Post>();

                var wpClient = App.client.WordPressClient;

                var queryBuilder = new PostsQueryBuilder();
                queryBuilder.PerPage = 10;
                queryBuilder.Page = page;
                if (query != null)
                {
                    queryBuilder.Search = query;
                }
                if (sectionId != null)
                {
                    queryBuilder.Categories = new int[] { (int)sectionId };
                }
                var posts = await wpClient.Posts.Query(queryBuilder);

                returningPosts = await ListPosts(posts, prevCount);

                return returningPosts;

            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
                return null;
            }
        }

        private static async Task<List<Post>> ListPosts(IEnumerable<WordPressPCL.Models.Post> posts, int prevCount)
        {
            var returningPosts = new List<Post>();

            var wpClient = App.client.WordPressClient;

            var mediaTasks = new List<Task<MediaItem>>();

            foreach (var aux in posts)
            {
                if (aux.FeaturedMedia != null && aux.FeaturedMedia != 0)
                {
                    mediaTasks.Add(wpClient.Media.GetByID(aux.FeaturedMedia, true, true));
                }
                else mediaTasks.Add(null);
                    
            }

            MediaItem[] images = await Task.WhenAll(mediaTasks);

            for (int i = 0; i < posts.Count(); i++)
            {
                var aux = posts.ElementAt(i);

                Image image = null;
                if (images[i] != null)
                {
                    image = new Image
                    {
                        Source = ImageSource.FromUri(new Uri(images[i].SourceUrl))
                    };
                }

                returningPosts.Add(new Post()
                {
                    Index = prevCount + returningPosts.Count,
                    Id = aux.Id,
                    Title = aux.Title.Rendered,
                    Content = aux.Content.Rendered,
                    PostedDate = aux.Date,
                    PostImage = image,
                    Section = ((CategoriesEnum)aux.Categories[0]).GetDescription()
                });
            }

            return returningPosts;
        }
    }
}

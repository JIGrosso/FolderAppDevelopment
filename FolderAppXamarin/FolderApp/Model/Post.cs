﻿using ExtensionMethods;
using FolderApp.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WordPressPCL.Utility;
using Xamarin.Forms;

namespace FolderApp.Model
{
    public class Post
    {
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


        public static async Task<List<Post>> UpdatePosts()
        {
            try
            {
                List<Post> returningPosts = new List<Post>();

                var queryBuilder = new PostsQueryBuilder();
                queryBuilder.PerPage = 1;
                queryBuilder.Page = 4;
                var posts = await App.client.Posts.Query(queryBuilder);

                foreach (var aux in posts)
                {
                    Image image = null;
                    if (aux.FeaturedMedia != null && aux.FeaturedMedia != 0)
                    {
                        var media = await App.client.Media.GetByID(aux.FeaturedMedia, true, true);
                        image = new Image
                        {
                            Source = ImageSource.FromUri(new Uri(media.SourceUrl))
                        };
                    }

                    returningPosts.Add(new Post()
                    {
                        Id = aux.Id,
                        Title = StringHelper.RemoveHtml(aux.Title.Rendered),
                        Content = StringHelper.RemoveHtml(aux.Content.Rendered),
                        PostedDate = aux.Date,
                        PostImage = image,
                        Section = ((CategoriesEnum)aux.Categories[0]).GetDescription()
                    });
                }

                return returningPosts;

            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
                return null;
            }
        }

        public static async Task<List<Post>> UpdatePostBySection(int sectionId)
        {
            try
            {
                List<Post> returningPosts = new List<Post>();

                var posts = await App.client.Posts.GetPostsByCategory(sectionId);

                foreach (var aux in posts)
                {
                    Image image = null;
                    if (aux.FeaturedMedia != null && aux.FeaturedMedia != 0)
                    {
                        var media = await App.client.Media.GetByID(aux.FeaturedMedia, true, true);
                        image = new Image
                        {
                            Source = ImageSource.FromUri(new Uri(media.SourceUrl))
                        };
                    }

                    returningPosts.Add(new Post()
                    {
                        Id = aux.Id,
                        Title = StringHelper.RemoveHtml(aux.Title.Rendered),
                        Content = StringHelper.RemoveHtml(aux.Content.Rendered),
                        PostedDate = aux.Date,
                        PostImage = image,
                        Section = aux.Categories[0].ToString()
                    });

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
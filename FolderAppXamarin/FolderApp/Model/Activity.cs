using FolderAppServices.BuddyPress.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using WordPressPCL.Models;

namespace FolderApp.Model
{
    public class Activity
    {
        public int Id { get; set; }
        
        public string Title { get; set; }

        public string Content { get; set; }

        public static async Task<ObservableCollection<Activity>> GetActivities(int page, int prevCount)
        {
            try
            {
                ObservableCollection<Activity> returningActivities = new ObservableCollection<Activity>();

                var bpClient = App.client.BuddyPressClient;

                var queryBuilder = new ActivitiesQueryBuilder();
                queryBuilder.PerPage = 15;
                queryBuilder.Page = page;
                queryBuilder.OrderBy = Order.DESC;

                var activities = await bpClient.Activities.Query(queryBuilder, true);

                returningActivities = await ListActivities(activities);

                App.ActivitiesCache = returningActivities;

                return returningActivities;

            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
                return null;
            }
        }

        private static async Task<ObservableCollection<Activity>> ListActivities(IEnumerable<FolderAppServices.BuddyPress.Models.Activity> posts)
        {
            var returningActivities = new ObservableCollection<Activity>();

            //var bpClient = App.client.BuddyPressClient;

            foreach (var aux in posts)
            {
                /*
                Image image = null;
                if (aux.FeaturedMedia != null && aux.FeaturedMedia != 0)
                {
                    var media = await wpClient.Media.GetByID(aux.FeaturedMedia, true, true);
                    image = new Image
                    {
                        Source = ImageSource.FromUri(new Uri(media.SourceUrl))
                    };
                }
                */

                returningActivities.Add(new Activity()
                {
                    Id = aux.Id,
                    Title = aux.Title,
                    Content = aux.Content.Rendered
                });
            }

            return returningActivities;
        }
    }
}

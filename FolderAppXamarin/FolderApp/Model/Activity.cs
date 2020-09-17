using FolderAppServices.BuddyPress.Utility;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FolderApp.Model
{
    class Activity
    {
        public int Id { get; set; }

        public static async Task<List<Activity>> GetActivities(int page, int prevCount)
        {
            try
            {
                List<Activity> returningActivities = new List<Activity>();

                var bpClient = App.client.BuddyPressClient;

                var queryBuilder = new ActivitiesQueryBuilder();
                queryBuilder.PerPage = 10;
                queryBuilder.Page = page;

                var activities = await bpClient.Activities.Query(queryBuilder, true);

                returningActivities = await ListActivities(activities, prevCount);

                return returningActivities;

            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
                return null;
            }
        }

        private static async Task<List<Activity>> ListActivities(IEnumerable<FolderAppServices.BuddyPress.Models.Activity> posts, int prevCount)
        {
            var returningActivities = new List<Activity>();

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
                    Id = aux.Id
                });
            }

            return returningActivities;
        }
    }
}

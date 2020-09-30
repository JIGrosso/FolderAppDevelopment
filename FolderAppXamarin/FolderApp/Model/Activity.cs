using ExtensionMethods;
using FolderAppServices.BuddyPress.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using WordPressPCL.Models;
using Xamarin.Forms;

namespace FolderApp.Model
{
    public class Activity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public Image UserThumbnail { get; set; }

        public DateTime Date { get; set; }

        public int TitleRowSpan
        {
            get
            {
                return string.IsNullOrEmpty(Content) ? 2 : 1;
            }
        }

        public static async Task<ObservableCollection<Activity>> GetActivities(int page, int[] existent)
        {
            try
            {
                ObservableCollection<Activity> returningActivities = new ObservableCollection<Activity>();

                var bpClient = App.client.BuddyPressClient;

                var queryBuilder = new ActivitiesQueryBuilder();
                queryBuilder.PerPage = 10;
                queryBuilder.Page = page;
                queryBuilder.OrderBy = Order.DESC;
                queryBuilder.Exclude = existent;

                var activities = await bpClient.Activities.Query(queryBuilder, true);

                returningActivities = await ListActivities(activities);

                foreach(Activity aux in returningActivities)
                {
                    App.AppCache.Activities[aux.Id] = aux;
                }

                return returningActivities;

            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
                return null;
            }
        }

        private static async Task<ObservableCollection<Activity>> ListActivities(IEnumerable<FolderAppServices.BuddyPress.Models.Activity> activities)
        {
            var returningActivities = new ObservableCollection<Activity>();
            var thumbnailTasks = new List<Task<Image>>();
            foreach (var aux in activities)
            {
                thumbnailTasks.Add(User.GetUserThumbnail(aux.UserId));
            }

            Image[] images = await Task.WhenAll(thumbnailTasks);

            for(int i = 0; i < activities.Count(); i++)
            {
                var aux = activities.ElementAt(i);
                returningActivities.Add(new Activity()
                {
                    Id = aux.Id,
                    Title = aux.Title,
                    Content = aux.Content.Rendered.RemoveParagraph(),
                    UserThumbnail = images[i],
                    Date = aux.Date
                });
            }

            return returningActivities;
        }
    }
}
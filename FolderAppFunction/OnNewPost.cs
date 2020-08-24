using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Azure.NotificationHubs;
using System.Net;

namespace FolderApp
{
    public static class OnNewPost
    {
        [FunctionName("OnNewPost")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            string post_author = data?.post.post_author;
            string post_title = data?.post.post_title;
            DateTime now = DateTime.Now;

            string title = $"{post_author} ha creado un nuevo post";
            string body = post_title;
            string badgeValue = "1";

            // Define the notification hub.
            NotificationHubClient hub =
                NotificationHubClient.CreateClientFromConnectionString(
                    "Endpoint=sb://folderapp.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=EDydYsB/T3zVlJXKmd4LA2c1jWOX15lhl5eRapWa0Zw=",
                    "FolderApp-Xamarin");

            // Define an iOS alert  
            var iOSalert =
                "{\"aps\":{\"alert\":\"" + body + "\", \"badge\":" + badgeValue + ", \"sound\":\"default\"},"
                + "\"inAppMessage\":\"" + body + "\"}";

            //hub.SendAppleNativeNotificationAsync(iOSalert).Wait();

            // Define an Anroid alert.

            var androidAlert = "{\"data\":{\"title\": \"" + title + "\",\"body\":\"" + body + "\"}}";

            hub.SendFcmNativeNotificationAsync(androidAlert).Wait();

            return new HttpResponseMessage(HttpStatusCode.OK);

        }
    }
}

using BuddyPress.Utility;
using FolderAppServices.BuddyPress.Client;
using FolderAppServices.BuddyPress.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WordPressPCL.Models.Exceptions;

namespace FolderAppServices.FolderBPClient
{
    namespace BuddyPress
    {
        /// <summary>
        ///     Main class containing the wrapper client with all public API endpoints.
        /// </summary>
        public class BuddyPressClient
        {
            private readonly HttpHelper _httpHelper;
            private readonly string _defaultPath;

            /// <summary>
            /// BuddyPressUri holds the BuddyPressUri API endpoint, e.g. "http://demo.wp-api.org/wp-json/buddypress/v1/"
            /// </summary>
            public string BuddyPressUri { get; private set; }

            /// <summary>
            /// Function called when a HttpRequest response to BuddyPress APIs are read
            /// Executed before trying to convert json content to a TClass object.
            /// </summary>
            public Func<string, string> HttpResponsePreProcessing
            {
                set
                {
                    _httpHelper.HttpResponsePreProcessing = value;
                }
            }

            /// <summary>
            /// Serialization/Deserialization settings for Json.NET library
            /// https://www.newtonsoft.com/json/help/html/SerializationSettings.htm
            /// </summary>
            public JsonSerializerSettings JsonSerializerSettings
            {
                set
                {
                    _httpHelper.JsonSerializerSettings = value;
                }
                get
                {
                    return _httpHelper.JsonSerializerSettings;
                }
            }

            /// <summary>
            /// Activities client interaction object
            /// </summary>
            public Activities Activities { get; }

            /*

            /// <summary>
            /// Authentication method
            /// </summary>
            public AuthMethod AuthMethod { get; set; }

            /// <summary>
            /// Posts client interaction object
            /// </summary>
            public Posts Posts { get; }

            /// <summary>
            /// Comments client interaction object
            /// </summary>
            public Comments Comments { get; }

            /// <summary>
            /// Tags client interaction object
            /// </summary>
            public Tags Tags { get; }

            /// <summary>
            /// Users client interaction object
            /// </summary>
            public Users Users { get; }

            /// <summary>
            /// Media client interaction object
            /// </summary>
            public Media Media { get; }

            /// <summary>
            /// Categories client interaction object
            /// </summary>
            public Categories Categories { get; }

            /// <summary>
            /// Pages client interaction object
            /// </summary>
            public Pages Pages { get; }

            /// <summary>
            /// Taxonomies client interaction object
            /// </summary>
            public Taxonomies Taxonomies { get; }

            /// <summary>
            /// Post Types client interaction object
            /// </summary>
            public PostTypes PostTypes { get; }

            /// <summary>
            /// Post Statuses client interaction object
            /// </summary>
            public PostStatuses PostStatuses { get; }

            /// <summary>
            /// Custom Request client interaction object
            /// </summary>
            public CustomRequest CustomRequest { get; }

            */

            /// <summary>
            ///     The BuddyPressClient holds all connection infos and provides methods to call BuddyPress APIs.
            /// </summary>
            /// <param name="uri">URI for Wordpress API endpoint, e.g. "http://demo.wp-api.org/wp-json/"</param>
            /// <param name="defaultPath">Points to the standard BuddyPress API endpoints</param>
            public BuddyPressClient(string uri, string defaultPath = "buddypress/v1/")
            {
                if (string.IsNullOrWhiteSpace(uri))
                {
                    throw new ArgumentNullException(nameof(uri));
                }
                if (!uri.EndsWith("/", StringComparison.Ordinal))
                {
                    uri += "/";
                }
                BuddyPressUri = uri;
                _defaultPath = defaultPath;

                _httpHelper = new HttpHelper(BuddyPressUri);

                Activities = new Activities(ref _httpHelper, _defaultPath);

                /*
                Comments = new Comments(ref _httpHelper, _defaultPath);
                Tags = new Tags(ref _httpHelper, _defaultPath);
                Users = new Users(ref _httpHelper, _defaultPath);
                Media = new Media(ref _httpHelper, _defaultPath);
                Categories = new Categories(ref _httpHelper, _defaultPath);
                Pages = new Pages(ref _httpHelper, _defaultPath);
                Taxonomies = new Taxonomies(ref _httpHelper, _defaultPath);
                PostTypes = new PostTypes(ref _httpHelper, _defaultPath);
                PostStatuses = new PostStatuses(ref _httpHelper, _defaultPath);
                CustomRequest = new CustomRequest(ref _httpHelper);
                */
            }

            #region auth methods

            /// <summary>
            /// Forget the JWT Auth Token, won't invalidate it serverside though
            /// </summary>
            public void Logout()
            {
                _httpHelper.JWToken = default;
            }

            /// <summary>
            /// Sets an existing JWToken
            /// </summary>
            /// <param name="token"></param>
            public void SetJWToken(string token)
            {
                _httpHelper.JWToken = token;
            }

            /// <summary>
            /// Gets the JWToken from the client
            /// </summary>
            /// <returns></returns>
            public string GetToken()
            {
                return _httpHelper.JWToken;
            }

            #endregion auth methods
        }
    }
}

using BuddyPress.Utility;
using FolderAppServices.BuddyPress.Models;
using FolderAppServices.BuddyPress.Utility;

namespace FolderAppServices.BuddyPress.Client
{
    /// <summary>
    /// Client class for interaction with Activities endpoint BP REST API
    /// </summary>
    public class Activities : CRUDOperation<Activity, ActivitiesQueryBuilder>
    {
        #region Init

        private const string _methodPath = "activity";

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="HttpHelper">reference to HttpHelper class for interaction with HTTP</param>
        /// <param name="defaultPath">path to site, EX. http://demo.com/wp-json/ </param>
        public Activities(ref HttpHelper HttpHelper, string defaultPath) : base(ref HttpHelper, defaultPath, _methodPath)
        {
        }

        #endregion Init
    }
}

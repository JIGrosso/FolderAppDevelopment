using BuddyPress.Utility;
using FolderAppServices.BuddyPress.Models;
using FolderAppServices.BuddyPress.Utility;
using System.Linq;
using System.Threading.Tasks;

namespace FolderAppServices.BuddyPress.Client
{
    public class Members : CRUDOperation<Member, MembersQueryBuilder>
    {
        #region Init

        private const string _methodPath = "members";

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="HttpHelper">reference to HttpHelper class for interaction with HTTP</param>
        /// <param name="defaultPath">path to site, EX. http://demo.com/wp-json/ </param>
        public Members(ref HttpHelper HttpHelper, string defaultPath) : base(ref HttpHelper, defaultPath, _methodPath)
        {
        }

        #endregion Init

        /// <summary>
        /// Get avatarUrls thumb and full given userId
        /// </summary>
        /// <param name="userId">UserId</param>
        /// <param name="embed">include embed info</param>
        /// <param name="useAuth">Send request with authentication header</param>
        /// <returns>List of posts</returns>
        public async Task<BPAvatarURL> GetUserAvatars(int userId, bool embed = false, bool useAuth = false)
        {
            BPAvatarURL[] response = await HttpHelper.GetRequest<BPAvatarURL[]>($"{DefaultPath}{_methodPath}/{userId}/avatar", embed, useAuth);
            return response.FirstOrDefault();
        }

        public async Task<Member> GetCurrentMember()
        {
            Member response = await HttpHelper.GetRequest<Member>($"{DefaultPath}{_methodPath}/me", true, true);
            return response;
        }
    }
}

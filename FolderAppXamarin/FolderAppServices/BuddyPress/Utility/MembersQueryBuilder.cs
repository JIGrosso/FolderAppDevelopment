using WordPressPCL.Utility;

namespace FolderAppServices.BuddyPress.Utility
{
    /// <summary>
    /// Activity Query Builder class to construct queries with valid parameters
    /// </summary>
    public class MembersQueryBuilder : QueryBuilder
    {   
        /// <summary>
        /// Current page of the collection.
        /// </summary>
        /// <remarks>Default: 1</remarks>
        [QueryText("page")]
        public int Page { get; set; }
        /// <summary>
        
        /// Maximum number of items to be returned in result set.
        /// </summary>
        /// <remarks>Default: 10</remarks>
        [QueryText("per_page")]
        public int PerPage { get; set; }
        
        /// <summary>
        /// Limit results to those matching a string.
        /// </summary>
        [QueryText("search")]
        public string Search { get; set; }

        /// <summary>
        /// Limit results to friends of a user. Default: 0
        /// </summary>
        [QueryText("user_id")]
        public int UserId { get; set; }

        /// <summary>
        /// Pass IDs of users to limit result set. Default: []
        /// </summary>
        [QueryText("user_ids")]
        public int[] UserIds { get; set; }

        /// <summary>
        /// Ensure result set excludes specific IDs.
        /// </summary>
        [QueryText("exclude")]
        public int[] Exclude { get; set; }
        
        /// <summary>
        /// Limit result set to specific IDs.
        /// </summary>
        [QueryText("include")]
        public int[] Include { get; set; }
    }
}

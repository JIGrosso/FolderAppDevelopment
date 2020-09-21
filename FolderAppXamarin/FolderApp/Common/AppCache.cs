using FolderApp.Model;
using System.Collections.Generic;

namespace FolderApp.Common
{
    public class AppCache
    {
        public Dictionary<int ,Activity> Activities { get; set; } = new Dictionary<int, Activity>();

        //public Dictionary<int, byte[]> UserThumbnails { get; set; } = new Dictionary<int, byte[]>();
    }
}

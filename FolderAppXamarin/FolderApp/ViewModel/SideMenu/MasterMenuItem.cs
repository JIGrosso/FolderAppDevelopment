using FolderApp.Common;
using System;

namespace FolderApp.Views.SideMenu
{

    public class MasterMenuItem
    {
        public MasterMenuItem()
        {
            TargetType = typeof(MasterMenuItem);
        }
        public int Id { get; set; }
        
        public string Title { get; set; }

        public Type TargetType { get; set; }

        public CategoriesEnum Category { get; set; }

        public string Icon { get; set; }

        public MasterMenuItem Self { get { return this; } }
    }
}
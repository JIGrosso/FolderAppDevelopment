using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderApp.Views
{

    public class SideMenuMasterMenuItem
    {
        public SideMenuMasterMenuItem()
        {
            TargetType = typeof(SideMenuMasterMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}
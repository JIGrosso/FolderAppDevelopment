using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FolderApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SideMenuMaster : ContentPage
    {
        public ListView ListView;

        public SideMenuMaster()
        {
            InitializeComponent();

            BindingContext = new SideMenuMasterViewModel();
            ListView = MenuItemsListView;
        }

        class SideMenuMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<SideMenuMasterMenuItem> MenuItems { get; set; }

            public SideMenuMasterViewModel()
            {
                MenuItems = new ObservableCollection<SideMenuMasterMenuItem>(new[]
                {
                    new SideMenuMasterMenuItem { Id = 0, Title = "Page 1" },
                    new SideMenuMasterMenuItem { Id = 1, Title = "Page 2" },
                    new SideMenuMasterMenuItem { Id = 2, Title = "Page 3" },
                    new SideMenuMasterMenuItem { Id = 3, Title = "Page 4" },
                    new SideMenuMasterMenuItem { Id = 4, Title = "Page 5" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}
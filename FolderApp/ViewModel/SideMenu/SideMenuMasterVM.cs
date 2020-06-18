using FolderApp.Views.SideMenu;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace FolderApp.ViewModel.SideMenu
{
    class SideMenuMasterVM : INotifyPropertyChanged
    {
        public ObservableCollection<MasterMenuItem> MenuItems { get; set; }

        public SideMenuMasterVM()
        {
            MenuItems = new ObservableCollection<MasterMenuItem>(new[]
            {
                    new MasterMenuItem { Id = 0, Title = "Institucionales" },
                    new MasterMenuItem { Id = 1, Title = "Recursos Humanos" },
                });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


    }
}

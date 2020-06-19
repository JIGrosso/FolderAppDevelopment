using FolderApp.Views;
using FolderApp.Views.SideMenu;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace FolderApp.ViewModel.SideMenu
{
    public class SideMenuMasterVM
    {
        public ObservableCollection<MasterMenuItem> MenuItems { get; set; }

        public SideMenuMasterVM()
        {
            MenuItems = new ObservableCollection<MasterMenuItem>(new[]
            {
                new MasterMenuItem { Id = 0, Title = "Institucionales", TargetType = typeof(InstitucionalPage) },
                new MasterMenuItem { Id = 1, Title = "Recursos Humanos", TargetType = typeof(RRHHPage) },
                new MasterMenuItem { Id = 2, Title = "Produccion", TargetType = typeof(ProduccionPage) },
                new MasterMenuItem { Id = 3, Title = "Capacitaciones", TargetType = typeof(CapacitacionesPage) },
                new MasterMenuItem { Id = 4, Title = "Social", TargetType = typeof(SocialPage) }
            });
        }

        public async void Navigate(MasterMenuItem selectedItem)
        {
            await (App.Current.MainPage as MasterDetailPage).Detail.Navigation.PushAsync((Page)Activator.CreateInstance(selectedItem.TargetType));
            (App.Current.MainPage as MasterDetailPage).IsPresented = false;
        }

    }
}

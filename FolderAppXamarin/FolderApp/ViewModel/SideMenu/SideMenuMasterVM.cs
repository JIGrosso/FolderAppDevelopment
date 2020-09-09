using static ExtensionMethods.MyExtensions;
using FolderApp.Common;
using FolderApp.Views;
using FolderApp.Views.SideMenu;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace FolderApp.ViewModel.SideMenu
{
    public class SideMenuMasterVM
    {
        public string Name { get; set; } = App.User.CompleteName;

        public Image Avatar { get; set; }

        public ObservableCollection<MasterMenuItem> MenuItems { get; set; }

        public SideMenuMasterVM()
        {
            MenuItems = new ObservableCollection<MasterMenuItem>(new[]
            {
                new MasterMenuItem { Id = 0, Title = "Institucionales", TargetType = typeof(SectionPage), Category = CategoriesEnum.Direccion },
                new MasterMenuItem { Id = 1, Title = "Recursos Humanos", TargetType = typeof(SectionPage), Category = CategoriesEnum.RRHH },
                new MasterMenuItem { Id = 2, Title = "Produccion", TargetType = typeof(SectionPage), Category = CategoriesEnum.Produccion },
                new MasterMenuItem { Id = 3, Title = "Capacitaciones", TargetType = typeof(SectionPage), Category = CategoriesEnum.Capacitaciones },
                new MasterMenuItem { Id = 4, Title = "Social", TargetType = typeof(SectionPage), Category = CategoriesEnum.Social }
            });

            Avatar = GetAvatarOrDefault(App.User.AvatarUrl, Name);
        }

        public async void Navigate(MasterMenuItem selectedItem)
        {
            await (App.Current.MainPage as MasterDetailPage).Detail.Navigation.PushAsync(new SectionPage(selectedItem.Category));
            (App.Current.MainPage as MasterDetailPage).IsPresented = false;
        }

    }
}

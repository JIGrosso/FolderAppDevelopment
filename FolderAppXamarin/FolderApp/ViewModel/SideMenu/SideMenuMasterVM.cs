using static ExtensionMethods.MyExtensions;
using FolderApp.Common;
using FolderApp.Views;
using FolderApp.Views.SideMenu;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.ComponentModel;
using System.Windows.Input;

namespace FolderApp.ViewModel.SideMenu
{
    public class SideMenuMasterVM : INotifyPropertyChanged
    {
        public string Name { get; set; } = App.User.CompleteName;

        public Image Avatar { get; set; }

        public ObservableCollection<MasterMenuItem> Categories { get; set; }

        public ObservableCollection<MasterMenuItem> MenuItems { get; set; }

        private MasterMenuItem selectedItem { get; set; }
        public MasterMenuItem SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedItem)));
            }
        }

        public SideMenuMasterVM()
        {
            var resources = Application.Current.Resources;
            Categories = new ObservableCollection<MasterMenuItem>(new[]
            {
                new MasterMenuItem { Id = 0, Title = "Institucionales", TargetType = typeof(SectionPage), Category = CategoriesEnum.Direccion, Icon = (string)resources["institucionalIcon"] },
                new MasterMenuItem { Id = 1, Title = "Recursos Humanos", TargetType = typeof(SectionPage), Category = CategoriesEnum.RRHH, Icon = (string)resources["rrhhIcon"] },
                new MasterMenuItem { Id = 2, Title = "Produccion", TargetType = typeof(SectionPage), Category = CategoriesEnum.Produccion, Icon = (string)resources["produccionIcon"] },
                new MasterMenuItem { Id = 3, Title = "Capacitaciones", TargetType = typeof(SectionPage), Category = CategoriesEnum.Capacitaciones, Icon = (string)resources["capacitacionesIcon"] },
                new MasterMenuItem { Id = 4, Title = "Social", TargetType = typeof(SectionPage), Category = CategoriesEnum.Social, Icon = (string)resources["socialIcon"] }
            });

            MenuItems = new ObservableCollection<MasterMenuItem>(new[]
            {
                new MasterMenuItem { Id = 5, Title = "Calendario", TargetType = typeof(NoDisponiblePage), Icon = (string)resources["calendarioIcon"]},
                new MasterMenuItem { Id = 6, Title = "Equipos - Proyectos", TargetType = typeof(NoDisponiblePage), Icon = (string)resources["equiposIcon"]},
                new MasterMenuItem { Id = 7, Title = "Tickets", TargetType = typeof(NoDisponiblePage), Icon = (string)resources["ticketsIcon"]},
                new MasterMenuItem { Id = 8, Title = "F.A.Q.", TargetType = typeof(NoDisponiblePage), Icon = (string)resources["faqIcon"]},
            });

            Avatar = GetAvatarOrDefault(App.User.AvatarUrl, Name);
        }

        public ICommand ItemTapped
        {
            get
            {
                return new Command((object sender) =>
                {
                    if (SelectedItem == null && sender == null)
                        return;

                    if (SelectedItem == null)
                    {
                        Navigate((MasterMenuItem)sender);
                    }
                    else
                    {
                        Navigate(SelectedItem);
                    }

                    SelectedItem = null;
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public async void Navigate(MasterMenuItem selectedItem)
        {
            if (selectedItem.TargetType == typeof(SectionPage))
            {
                await (App.Current.MainPage as MasterDetailPage).Detail.Navigation.PushAsync(new SectionPage(selectedItem.Category));
            }
            if (selectedItem.TargetType == typeof(NoDisponiblePage))
            {
                await (App.Current.MainPage as MasterDetailPage).Detail.Navigation.PushAsync(new NoDisponiblePage(selectedItem.Title));
            }
            (App.Current.MainPage as MasterDetailPage).IsPresented = false;
        }

        public ICommand OnNoticiasTapped
        {
            get
            {
                return new Command(async () =>
                {
                    await (App.Current.MainPage as MasterDetailPage).Detail.Navigation.PushAsync(new SectionPage(CategoriesEnum.Noticias));
                    (App.Current.MainPage as MasterDetailPage).IsPresented = false;
                });
            }
        }
    }
}
using FolderApp.ViewModel.SideMenu;
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

namespace FolderApp.Views.SideMenu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SideMenuMaster : ContentPage
    {
        public ListView ListView;

        public SideMenuMaster()
        {
            InitializeComponent();

            BindingContext = new SideMenuMasterVM();
            ListView = MenuItemsListView;
        }


        private void MenuItemsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var aux = e.SelectedItem;
            //(App.Current.MainPage as MasterDetailPage).Detail.Navigation.PushAsync();
        }
    }

}
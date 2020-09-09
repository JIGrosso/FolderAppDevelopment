using FolderApp.Model;
using FolderApp.ViewModel.SideMenu;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FolderApp.Views.SideMenu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SideMenuMaster : ContentPage
    {
        SideMenuMasterVM viewModel;

        public SideMenuMaster()
        {

            InitializeComponent();

            viewModel = new SideMenuMasterVM();

            BindingContext = viewModel;
        }

        private void MenuItemsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterMenuItem;

            if(item != null)
            {
                viewModel.Navigate(item);
                MenuItemsList.SelectedItem = null;
            }

        }

        private async void Logout_TappedAsync(object sender, EventArgs e)
        {
            User.Logout();

            bool answer = await DisplayAlert("Cerrar sesión", "Esta seguro que desea cerrar sesión?", "Si", "No");
            if (answer) {
                App.Current.MainPage = new LoginPage();
            }
        }
    }

}
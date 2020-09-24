using FolderApp.ViewModel.SideMenu;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FolderApp.Views.Siderbar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HeaderView : ContentView
    {
        public HeaderView()
        {
            InitializeComponent();
        }

        private async void TapGestureRecognizer_ProfileTapped(object sender, EventArgs e)
        {
            await (App.Current.MainPage as MasterDetailPage).Detail.Navigation.PushAsync(new ProfilePage((BindingContext as SideMenuMasterVM).Avatar));
            (App.Current.MainPage as MasterDetailPage).IsPresented = false;
        }
    }
}
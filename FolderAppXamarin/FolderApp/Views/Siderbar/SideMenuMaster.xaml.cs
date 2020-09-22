using FolderApp.Common;
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

        private async void Noticias_TappedAsync(object sender, EventArgs e)
        {
            await (App.Current.MainPage as MasterDetailPage).Detail.Navigation.PushAsync(new SectionPage(CategoriesEnum.Noticias));
            (App.Current.MainPage as MasterDetailPage).IsPresented = false;
        }
    }

}
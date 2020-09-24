using FolderApp.Model;
using FolderApp.ViewModel;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FolderApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage(Image avatar)
        {
            BindingContext = new ProfileVM(avatar);
            InitializeComponent();
        }

        private async void Logout_TappedAsync(object sender, EventArgs e)
        {
            User.Logout();

            bool answer = await DisplayAlert("Cerrar sesión", "Esta seguro que desea cerrar sesión?", "Si", "No");
            if (answer)
            {
                App.Current.MainPage = new LoginPage();
            }
        }
    }
}
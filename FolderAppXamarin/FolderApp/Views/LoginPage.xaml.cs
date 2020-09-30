using FolderApp.ViewModel;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FolderApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {

        LoginVM viewModel;

        public LoginPage()
        {
            InitializeComponent();

            viewModel = new LoginVM();
            BindingContext = viewModel;

        }

        private void loginButton_Clicked(object sender, EventArgs e)
        {
            viewModel.Login();
        }


    }
}
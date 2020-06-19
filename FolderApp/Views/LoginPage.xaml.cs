using FolderApp.ViewModel;
using FolderApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
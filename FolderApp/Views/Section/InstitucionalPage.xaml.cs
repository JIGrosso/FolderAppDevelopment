using FolderApp.ViewModel.Secciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FolderApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InstitucionalPage : ContentPage
    {
        InstitucionalVM viewModel;

        public InstitucionalPage()
        {
            ((App.Current.MainPage as MasterDetailPage).Detail as NavigationPage).BarBackgroundColor = Color.FromHex("#B20207");

            InitializeComponent();

            viewModel = new InstitucionalVM();
            BindingContext = viewModel;

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.UpdatePostsInstitucionales();
        }

    }
}
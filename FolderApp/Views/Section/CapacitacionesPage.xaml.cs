using FolderApp.Model;
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
    public partial class CapacitacionesPage : ContentPage
    {
        Post post;

        public CapacitacionesPage()
        {
            ((App.Current.MainPage as MasterDetailPage).Detail as NavigationPage).BarBackgroundColor = Color.FromHex("#27818E");

            InitializeComponent();

            post = new Post();
            BindingContext = post;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //Traer todos los post de la sección capacitaciones.
        }
    }
}
using FolderApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FolderApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FAQPage : ContentPage
    {
        public FAQPage()
        {

            BindingContext = new FAQVM();

            InitializeComponent();
        }
    }
}
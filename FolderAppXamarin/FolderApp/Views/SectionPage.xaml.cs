﻿using FolderApp.Common;
using FolderApp.ViewModel.Section;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FolderApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SectionPage : ContentPage
    {
        SectionVM viewModel;

        public SectionPage(CategoriesEnum category)
        {
            InitializeComponent();

            viewModel = new SectionVM(category);
            BindingContext = viewModel;
            ((App.Current.MainPage as MasterDetailPage).Detail as NavigationPage).BarBackgroundColor = viewModel.TitleBackgroundColor;
            viewModel.UpdatePostsGeneric();
        }

        public void OnCollectionViewScrolled(double verticalDelta)
        {
            throw new System.NotImplementedException();
        }

        private void SearchBar_SearchButtonPressed(object sender, System.EventArgs e)
        {
            (BindingContext as SectionVM).OnSearchButtonPressed();
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            (BindingContext as SectionVM).OnTextChanged();
        }
    }
}
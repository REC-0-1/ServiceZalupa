using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Net.NetworkInformation;
using Microsoft.Maui.Controls;

namespace Service
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        private void OnApprovedFilterSwitchToggled(object sender, ToggledEventArgs e)
        {
            if (BindingContext is MainPageViewModel viewModel)
            {
                viewModel.FilterOffers(e.Value);
            }
        }

        private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
        {
            // Логика обработки изменения текста в SearchBar
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            (BindingContext as MainPageViewModel)?.LoadOffers();
        }
    }
}
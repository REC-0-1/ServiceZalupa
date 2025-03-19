using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.Maui.Controls;
using AndroidX.Lifecycle;

namespace Service
{
    public partial class AddOfferPage : ContentPage
    {

        public AddOfferPage(AddOfferPageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;

            if (viewModel.Id > 0)
            {
                viewModel.LoadOfferCommand.Execute(viewModel.Id);
            }
        }
    }
}
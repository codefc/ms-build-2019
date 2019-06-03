using Fumec.Mobile.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Fumec.Mobile
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private MainPageViewModel _viewModel;

        public MainPage()
        {
            InitializeComponent();
            _viewModel = new MainPageViewModel();

            this.BindingContext = _viewModel;

            
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await _viewModel.LoadAsync();

        }
    }
}

using Microsoft.Maui.Controls;
using HSUMauiApp.ViewModels;
using HSUMauiApp.Services;

namespace HSUMauiApp.Views
{
    public partial class LoginPage : ContentPage
    {
        private LoginViewModel _viewModel;

        public LoginPage()
        {
            InitializeComponent();
            _viewModel = new LoginViewModel();
            BindingContext = _viewModel;
        }
    }
}


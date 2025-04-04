using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace HSUMauiApp.Views
{
    public partial class LandingPage : ContentPage

    {
        public LandingPage()
        {
            InitializeComponent();
            NavigateToLogin();
        }

        private async void NavigateToLogin()
        {
            await Task.Delay(3000); // Chờ 3 giây
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}

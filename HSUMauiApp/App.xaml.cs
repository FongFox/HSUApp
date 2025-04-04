using Microsoft.Maui.Storage;

namespace HSUMauiApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Kiểm tra trạng thái đăng nhập
            if (Preferences.ContainsKey("IsLoggedIn") && Preferences.Get("IsLoggedIn", false))
            {
                MainPage = new AppShell();
                Shell.Current.GoToAsync("//HomePage"); // Đã đăng nhập → vào Home luôn
            }
            else
            {
                MainPage = new AppShell();
                Shell.Current.GoToAsync("//LandingPage"); // Chưa đăng nhập → vào LandingPage
            }
        }
    }
}

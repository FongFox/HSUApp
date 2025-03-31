using System;
using Microsoft.Maui.Controls;

namespace HSUMauiApp.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            string email = EmailEntry.Text;
            string password = PasswordEntry.Text;

            // Giả lập kiểm tra đăng nhập (backend xử lý)
            if (email == "student@hoasen.edu.vn" && password == "123456")
            {
                await DisplayAlert("Thành công", "Đăng nhập thành công!", "OK");
                await Navigation.PushAsync(new HomePage()); // Chuyển đến trang HomePage
            }
            else
            {
                await DisplayAlert("Lỗi", "Email hoặc mật khẩu không đúng!", "Thử lại");
            }
        }
    }
}

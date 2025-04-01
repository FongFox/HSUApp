using System;
using Microsoft.Maui.Controls;
using HSUMauiApp.Services;
using HSUMauiApp.ViewModels;

namespace HSUMauiApp.Views;

public partial class LandingPage : ContentPage
{
    private readonly LoginViewModel _loginViewModel;

    public LandingPage(ApiService apiService)
    {
        InitializeComponent();
        _loginViewModel = new LoginViewModel(apiService);
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        // Kiểm tra xem EmailEntry và PasswordEntry có null không
        if (EmailEntry == null || PasswordEntry == null)
        {
            await DisplayAlert("Lỗi", "Email hoặc Mật khẩu không hợp lệ!", "OK");
            return;
        }

        // Lấy giá trị và làm sạch dữ liệu (loại bỏ khoảng trắng thừa)
        string email = EmailEntry.Text?.Trim();
        string password = PasswordEntry.Text?.Trim();

        // Kiểm tra nếu email hoặc password là null hoặc rỗng
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            await DisplayAlert("Lỗi", "Vui lòng nhập đầy đủ email và mật khẩu!", "OK");
            return;
        }

        // Gọi LoginViewModel để xử lý đăng nhập
        var (success, message) = await _loginViewModel.LoginAsync(email, password);
        if (success)
        {
            await DisplayAlert("Đăng nhập", "Đăng nhập thành công!", "OK");
            try
            {
                await Shell.Current.GoToAsync("//HomePage"); // Điều hướng sang HomePage
            }
            catch (Exception ex)
            {
                await DisplayAlert("Lỗi", $"Không thể điều hướng: {ex.Message}", "OK");
            }
        }
        else
        {
            await DisplayAlert("Lỗi", message, "Thử lại");
        }
    }
}
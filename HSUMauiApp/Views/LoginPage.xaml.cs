﻿using System;
using Microsoft.Maui.Controls;

namespace HSUMauiApp.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
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

        // So sánh giá trị
        if (email == "sinhvien@hsu.edu.vn" && password == "123456")
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
            await DisplayAlert("Lỗi", $"Email hoặc mật khẩu không đúng!\nEmail nhập: '{email}'\nMật khẩu nhập: '{password}'", "Thử lại");
        }
    }
}
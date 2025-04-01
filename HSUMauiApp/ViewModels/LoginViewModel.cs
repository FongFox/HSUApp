using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HSUMauiApp.Services;

namespace HSUMauiApp.ViewModels
{
    public class LoginViewModel
    {
        private readonly ApiService _apiService;

        public LoginViewModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task LoginAsync(string email, string password)
        {
            try
            {
                bool isLoggedIn = await _apiService.LoginAsync(email, password);
                if (!isLoggedIn)
                {
                    // Hiển thị thông báo lỗi
                    await DisplayAlert("Lỗi", "Đăng nhập không thành công", "OK");
                }
                else
                {
                    // Đăng nhập thành công, chuyển đến trang chủ
                    await Navigation.PushAsync(new HomePage());
                }
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi
                await DisplayAlert("Lỗi", ex.Message, "OK");
            }
        }
    }
}

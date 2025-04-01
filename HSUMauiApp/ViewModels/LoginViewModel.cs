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
                var (success, message) = await _apiService.LoginAsync(email, password);
                if (success)
                {
                    // Đăng nhập thành công, chuyển đến trang chủ
                    await Navigation.PushAsync(new HomePage());
                }
                else
                {
                    // Hiển thị thông báo lỗi
                    await DisplayAlert("Lỗi", message, "OK");
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

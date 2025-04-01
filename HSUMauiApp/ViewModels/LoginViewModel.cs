using System;
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

        public async Task<(bool success, string message)> LoginAsync(string email, string password)
        {
            try
            {
                var (success, message) = await _apiService.LoginAsync(email, password);
                return (success, message);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
    }
}
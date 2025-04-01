using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HSUMauiApp.Models;
using HSUMauiApp.Services;
using Newtonsoft.Json;

namespace HSUMauiApp.ViewModels
{
    public class HomeViewModel
    {
        private readonly ApiService _apiService;

        public HomeViewModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task LoadMenuModelsAsync()
        {
            try
            {
                var res = await _apiService.GetMenuModelAsync();
                // Làm gì đó với menuModels: lấy thông tin từ json để gán giá trị dữ liệu vào biến, từ đó có thể hiển thị ra view.
                var menuItemList = res.ToList();
            }
            catch (HttpRequestException ex)
            {
                // Xử lý lỗi HTTP
                Debug.WriteLine("Lỗi HTTP xảy ra khi gọi GetMenuModelAsync(): " + ex.Message);
            }
            catch (JsonException ex)
            {
                // Xử lý lỗi JSON
                Debug.WriteLine("Lỗi JSON xảy ra khi gọi GetMenuModelAsync(): " + ex.Message);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi chung
                Debug.WriteLine("Lỗi xảy ra khi gọi GetMenuModelAsync(): " + ex.Message);
            }
        }
    }
}

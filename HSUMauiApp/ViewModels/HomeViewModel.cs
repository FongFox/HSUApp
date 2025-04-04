using System.Windows.Input;
using HSUMauiApp.Models;
using HSUMauiApp.Services;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;

namespace HSUMauiApp.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private ObservableCollection<MenuModel> _menuItems;

        public ObservableCollection<MenuModel> MenuItems
        {
            get => _menuItems;
            set => SetProperty(ref _menuItems, value);
        }

        public HomeViewModel()
        {
            MenuItems = new ObservableCollection<MenuModel>();
        }

        public async Task LoadMenuModelsAsync()
        {
            // Giả lập dữ liệu, có thể thay thế bằng gọi API thật
            await Task.Delay(500);
            MenuItems = new ObservableCollection<MenuModel>
            {
                new MenuModel { name = "Lịch học", description = "Xem thời khóa biểu", icon = "📅", iconColor = "#003087" },
                new MenuModel { name = "Điểm số", description = "Xem điểm học tập", icon = "📊", iconColor = "#FF5733" },
                new MenuModel { name = "Thông báo", description = "Xem thông báo mới", icon = "🔔", iconColor = "#FFC300" }
            };
        }
    }
}

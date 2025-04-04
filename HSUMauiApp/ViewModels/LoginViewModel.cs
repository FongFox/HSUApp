using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace HSUMauiApp.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _username;
        private string _password;
        private string _errorMessage;
        private bool _isErrorVisible;

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }

        public bool IsErrorVisible
        {
            get => _isErrorVisible;
            set
            {
                _isErrorVisible = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoginCommand { get; }
        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await OnLogin());  // Gọi hàm Login
        }

        private async Task OnLogin()  // Sửa void thành Task
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                ErrorMessage = "Vui lòng nhập email và mật khẩu!";
                IsErrorVisible = true;
                return;
            }

            if (Username == "sinhvien@hsu.edu.vn" && Password == "123456")
            {
                // Ẩn lỗi nếu đăng nhập đúng
                IsErrorVisible = false;
                ErrorMessage = "";

                // Chuyển đến trang HomePage
                await Shell.Current.GoToAsync("//HomePage");
            }
            else
            {
                // Hiển thị lỗi nếu sai tài khoản/mật khẩu
                ErrorMessage = "Email hoặc mật khẩu không đúng!";
                IsErrorVisible = true;
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

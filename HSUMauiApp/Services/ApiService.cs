using System;
using System.Text;
using HSUMauiApp.Models;
using Newtonsoft.Json;

namespace HSUMauiApp.Services;

public class ApiService
{
  private readonly HttpClient _httpClient;

  public ApiService()
  {
        //_httpClient = new HttpClient
        //{
        //  BaseAddress = new Uri("https://10.0.2.2:7107/api/")
        //};

        var handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
        };
        _httpClient = new HttpClient(handler)
        {
            BaseAddress = new Uri("https://10.0.2.2:7107/api/")
        };
    }

  // public async Task<bool> LoginAsync(string email, string password)
  // {
  //   var userLogin = new User { Email = email, Password = password };
  //   var response = await _httpClient.PostAsync(
  //     "auth/login",
  //     new StringContent(JsonConvert.SerializeObject(userLogin),
  //     Encoding.UTF8,
  //     "application/json"
  //   ));

  //   return response.IsSuccessStatusCode;
  // }

  public async Task<(bool success, string message)> LoginAsync(string email, string password)
  {
    try
    {
      var userLogin = new { Email = email, Password = password };
      var json = JsonConvert.SerializeObject(userLogin);
      var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

      var response = await _httpClient.PostAsync("auth/login", httpContent);

      if (response.IsSuccessStatusCode)
      {
        var responseContent = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<dynamic>(responseContent);
        return (true, result.message.ToString());
      }
      else
      {
        var errorContent = await response.Content.ReadAsStringAsync();
        var errorResult = JsonConvert.DeserializeObject<dynamic>(errorContent);
        return (false, errorResult.message.ToString());
      }
    }
    catch (Exception ex)
    {
      // Log exception nếu cần
      return (false, $"An error occurred: {ex.Message}");
    }
  }

  public async Task<IEnumerable<MenuModel>> GetMenuModelAsync() {
      try
      {
        var response = await _httpClient.GetAsync("home/icons");

        if (response.IsSuccessStatusCode)
        {
          var responseContent = await response.Content.ReadAsStringAsync();
          var menuModels = JsonConvert.DeserializeObject<IEnumerable<MenuModel>>(responseContent);

          return menuModels;
        }
        else
        {
          var errorContent = await response.Content.ReadAsStringAsync();
          var errorResult = JsonConvert.DeserializeObject<dynamic>(errorContent);
          throw new Exception(errorResult.message);
        }
      }
      catch (Exception ex)
      {
          // Log exception nếu cần
          throw new Exception($"An error occurred: {ex.Message}");
      }
  }
}

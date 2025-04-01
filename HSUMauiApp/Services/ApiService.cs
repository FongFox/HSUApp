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
    _httpClient = new HttpClient
    {
      BaseAddress = new Uri("https://localhost:8081/api/")
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

}

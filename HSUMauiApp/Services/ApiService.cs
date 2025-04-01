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

  public async Task<bool> LoginAsync(string email, string password)
  {
    var userLogin = new User { Email = email, Password = password };
    var response = await _httpClient.PostAsync(
      "auth/login",
      new StringContent(JsonConvert.SerializeObject(userLogin),
      Encoding.UTF8,
      "application/json"
    ));

    return response.IsSuccessStatusCode;
  }

}

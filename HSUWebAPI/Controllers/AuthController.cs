using System;
using HSUWebAPI.Dto;
using HSUWebAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace HSUWebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    public bool Login([FromBody] LoginDto userLogin)
    {
        User simpleUser = new User();
        simpleUser.Name = "user";
        simpleUser.Password = "123456";

        string[] symbols = new string[] { "📱", "💡", "🔔", "🛠️", "📲", "⚙️", "🔒", "📁", "📤", "🎨", "📞", "📧", "🌐", "📋", "📝", "📦", "📌", "🔍", "🔗" };

        if (userLogin.name != simpleUser.Name || userLogin.password != simpleUser.Password) {
            return false;
        }

        return true;
    }
}

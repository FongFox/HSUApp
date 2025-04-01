using System;
using HSUWebAPI.DTOs;

//using HSUWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HSUWebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    public bool Login([FromBody] LoginDto userLogin)
    {
        var simpleUser = new LoginDto()
        {
            Name = "user",
            Password = "1234"
        };

        if (userLogin.Name != simpleUser.Name || userLogin.Password != simpleUser.Password) {
            return false;
        }

        return true;
    }
}

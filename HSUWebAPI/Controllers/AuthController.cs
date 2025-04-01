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
            Email = "user@hoasen.edu.vn",
            Password = "1234"
        };

        if (userLogin.Email != simpleUser.Email || userLogin.Password != simpleUser.Password) {
            return false;
        }

        return true;
    }
}

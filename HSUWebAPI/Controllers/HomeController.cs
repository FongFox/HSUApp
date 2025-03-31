using System;
using System.Drawing;
using System.Text.Json.Serialization;
using HSUWebAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace HSUWebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HomeController : ControllerBase
{
  private readonly List<MenuModel> _menuModels = new List<MenuModel>(){
      new MenuModel {
        Name = "Absent Report",
        Icon = "running-man",
        TargetPage = "absent-report",
        IconColor = "#000080"
      },
      new MenuModel {
        Name = "Advisor Feedback",
        Icon = "chart",
        TargetPage = "advisor-feedback",
        IconColor = "#000080"
      },
      new MenuModel {
        Name = "Attendence",
        Icon = "location-tick",
        TargetPage = "attendence",
        IconColor = "#000080"
      },
      new MenuModel {
        Name = "Book Room",
        Icon = "room-book",
        TargetPage = "/book-room",
        IconColor = "#000080"
      },
      new MenuModel {
        Name = "Course Feedback",
        Icon = "chart",
        TargetPage = "course-feedback",
        IconColor = "#000080"
      }

  };

  [HttpGet("icons")]
  public ActionResult<IEnumerable<MenuModel>> GetIcons()
  {
    var menuModels = _menuModels;

    return Ok(menuModels);
  }
}

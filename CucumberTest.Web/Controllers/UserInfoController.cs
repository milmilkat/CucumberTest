using CucumberTest.Business.Models;
using CucumberTest.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CucumberTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserInfoController : ControllerBase
    {
        private readonly IUserInfoService _userInfoService;

        public UserInfoController(IUserInfoService userInfoService)
        {
            _userInfoService = userInfoService;
        }

        [HttpGet, Route("{cash}")]
        public IActionResult Get([FromRoute] decimal cash, [FromQuery] string? fullName)
        {
            UserInfo userInfo = new UserInfo();

            try
            {
                userInfo = _userInfoService.GetUserDetailsWithCashInWords(fullName, cash);
            }
            catch(ArgumentException e)
            {
                return BadRequest(e.Message);
            }

            return Ok(userInfo);
        }
    }
}

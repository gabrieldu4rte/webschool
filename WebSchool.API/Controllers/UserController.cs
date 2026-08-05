using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebSchool.API.Models;
using WebSchool.Application.DTOs.Course;
using WebSchool.Application.DTOs.User;
using WebSchool.Application.Interfaces;
using WebSchool.Application.Services;
using WebSchool.Domain.Account;

namespace WebSchool.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAuthenticateService _authenticate;
        public UserController(IUserService userService, IAuthenticateService authenticate)
        {
            _userService = userService;
            _authenticate = authenticate;
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(UserPostDTO userPostDTO)
        {
            var user = await _userService.AddAsync(userPostDTO);
            var token = _authenticate.GenerateToken(user.Id, user.Email.ToLower(), user.Profile);
            return Ok(new { Name = user.Name, Token = token });
        }

        [HttpPost("login")]
        public async Task<ActionResult> GetTokenUser(UserLogin userLogin)
        {
            var user = await _authenticate.AuthenticateAsync(userLogin.Email, userLogin.Password);

            var token = _authenticate.GenerateToken(user.Id, user.Email.ToLower(), user.Profile);
            return Ok(new { Name = user.Name, Token = token });
        }

    }
}

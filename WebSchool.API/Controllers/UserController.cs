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
        private readonly IAuthenticate _authenticate;
        public UserController(IUserService userService, IAuthenticate authenticate)
        {
            _userService = userService;
            _authenticate = authenticate;
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(UserPostDTO userPostDTO)
        {
            var userExists = await _authenticate.UserExists(userPostDTO.Email);
            if (userExists)
            {
                return BadRequest(new { message = "Já existe um usuário utilizando este e-mail" });
            }
            var user = await _userService.AddAsync(userPostDTO);
            var token = _authenticate.GenerateToken(user.Id, user.Email.ToLower(), user.Profile);
            return Ok(new { Name = user.Name, Token = token });
        }

        [HttpPost("login")]
        public async Task<ActionResult> GetTokenUser(UserLogin userLogin)
        {
            var user = await _authenticate.GetUserByEmail(userLogin.Email);
            if (user == null)
                return BadRequest(new { message = "Usuário ou senha inválidos." });
            var validUser = await _authenticate.AuthenticateAsync(userLogin.Email, userLogin.Password);
            if (!validUser)
                return BadRequest(new { message = "Usuário ou senha inválidos." });

            var token = _authenticate.GenerateToken(user.Id, user.Email.ToLower(), user.Profile);
            return Ok(new { Name = user.Name, Token = token });
        }

    }
}

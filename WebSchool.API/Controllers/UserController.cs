using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebSchool.API.Extensions;
using WebSchool.API.Models;
using WebSchool.Application.DTOs.Course;
using WebSchool.Application.DTOs.User;
using WebSchool.Application.Interfaces;
using WebSchool.Application.Services;
using WebSchool.Domain.Account;
using WebSchool.Infra.Ioc;

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

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetAllUsers([FromQuery] PaginationParams paginationParams)
        {
            var users = await _userService.GetAllAsync(paginationParams.PageNumber, paginationParams.PageSize);

            Response.AddPaginationHeader(new PaginationHeader(paginationParams.PageNumber, paginationParams.PageSize, users.TotalCount, users.TotalPages));
            return Ok(users);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult> UpdateUser(UserPutDTO userPutDTO)
        {
            await _userService.UpdateAsync(User.GetUserId(),userPutDTO);
            return Ok(new {message = "Usuário atualizado com sucesso!" });
        }

        [HttpPut("password")]
        [Authorize]
        public async Task<ActionResult> ChangePassword(PasswordChangeDTO passwordChangeDTO)
        {
            await _userService.PasswordChangeAsync(User.GetUserId(), passwordChangeDTO);
            return Ok(new { message = "Senha alterada com sucesso!" });
        }

    }
}

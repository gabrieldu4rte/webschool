using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using WebSchool.Application.DTOs.User;
using WebSchool.Application.Exceptions;
using WebSchool.Application.Interfaces;
using WebSchool.Domain.Account;
using WebSchool.Domain.Entities;
using WebSchool.Domain.Interfaces;

namespace WebSchool.Application.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthenticate _authenticate;
        public AuthenticateService(IUserRepository userRepository, IAuthenticate authenticate)
        {
            _userRepository = userRepository;
            _authenticate = authenticate;
        }

        public async Task<UserGetDTO> AuthenticateAsync(string email, string password)
        {
            var user = await _userRepository.GetUserByEmail(email);
            if (user == null || user.IsDeleted)
                throw new BadRequestException("Usuário ou senha inválidos");

            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            if(!computedHash.SequenceEqual(user.PasswordHash))
                throw new BadRequestException("Usuário ou senha inválidos");
            return new UserGetDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Profile = user.Profile.ToString()
            };
        }

        public string GenerateToken(int id, string email, string role)
        {
            return _authenticate.GenerateToken(id, email, role);
        }
    }
}

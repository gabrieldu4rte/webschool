using System;
using System.Collections.Generic;
using System.Text;
using WebSchool.Domain.Entities;

namespace WebSchool.Domain.Account
{
    public interface IAuthenticate
    {
        string GenerateToken(int id, string email, string role);
        Task<User> GetUserByEmail(string email);
        Task<bool> UserExists(string email);
        Task<bool> AuthenticateAsync(string email, string password);
    }
}

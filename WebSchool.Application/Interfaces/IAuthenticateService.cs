using System;
using System.Collections.Generic;
using System.Text;
using WebSchool.Application.DTOs.User;
using WebSchool.Domain.Entities;

namespace WebSchool.Application.Interfaces
{
    public interface IAuthenticateService
    {
        Task<UserGetDTO> AuthenticateAsync(string email, string password);
        string GenerateToken(int id, string email, string role);
    }
}

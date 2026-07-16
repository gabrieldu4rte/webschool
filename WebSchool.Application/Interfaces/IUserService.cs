using System;
using System.Collections.Generic;
using System.Text;
using WebSchool.Application.DTOs.User;
using WebSchool.Domain.Entities;

namespace WebSchool.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserGetDTO> GetByIdAsync(int id);
        Task<List<UserGetDTO>> GetAllAsync();

        Task<UserGetDTO> AddAsync(UserPostDTO user);
        Task<UserGetDTO> UpdateAsync(int userId, UserPutDTO user);
        Task<UserGetDTO> DeleteAsync(int id);
    }
}

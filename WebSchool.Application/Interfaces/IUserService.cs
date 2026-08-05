using System;
using System.Collections.Generic;
using System.Text;
using WebSchool.Application.DTOs.User;
using WebSchool.Domain.Entities;
using WebSchool.Domain.Pagination;

namespace WebSchool.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserGetDTO> GetByIdAsync(int id);
        Task<PagedList<UserGetDTO>> GetAllAsync(int pageNumber, int pageSize);
        Task<UserGetDTO> AddAsync(UserPostDTO user);
        Task<UserGetDTO> UpdateAsync(int userId, UserPutDTO user);
        Task<UserGetDTO> DeleteAsync(int id);
        Task<bool> ExistUserAsync();
        Task<UserGetDTO> GetUserByEmail(string email);
    }
}

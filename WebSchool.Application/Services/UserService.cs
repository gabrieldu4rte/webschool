using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using WebSchool.Application.DTOs.Tuition;
using WebSchool.Application.DTOs.User;
using WebSchool.Application.Exceptions;
using WebSchool.Application.Interfaces;
using WebSchool.Domain.Entities;
using WebSchool.Domain.Interfaces;
using WebSchool.Domain.Pagination;

namespace WebSchool.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserGetDTO> AddAsync(UserPostDTO userPostDTO)
        {
            var userExists = await _userRepository.UserExists(userPostDTO.Email);
            if (userExists) {
                throw new InvalidOperationException("Já existe um usuário utilizando este e-mail");
            }

            using var hmac = new HMACSHA512();
            byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userPostDTO.Password));
            byte[] passwordSalt = hmac.Key;

            var existingUser = await _userRepository.ExistUserAsync();

            var newUser = new User
            {
                Name = userPostDTO.Name,
                Email = userPostDTO.Email,
                IsDeleted = false,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Profile = existingUser ? "Aluno" : "Administrador"
            };
            var addedUser = await _userRepository.AddAsync(newUser);
            return new UserGetDTO
            {
                Id = addedUser.Id,
                Name = addedUser.Name,
                Email = addedUser.Email,
                Profile = addedUser.Profile
            };
        }

        public async Task<UserGetDTO> DeleteAsync(int id)
        {
            var deletedUser = await _userRepository.DeleteAsync(id);
            if (deletedUser == null)
            {
                throw new NotFoundException("Usuário não encontrado");
            }
            return new UserGetDTO
            {
                Id = deletedUser.Id,
                Name = deletedUser.Name,
                Email = deletedUser.Email,
                Profile = deletedUser.Profile
            };
        }

        public async Task<bool> ExistUserAsync()
        {
            return await _userRepository.ExistUserAsync();
        }

        public async Task<PagedList<UserGetDTO>> GetAllAsync(int pageNumber, int pageSize)
        {
            var users = await _userRepository.GetAllAsync(pageNumber, pageSize);
            var userDTOs = new List<UserGetDTO>();
            userDTOs.AddRange(users.Select(user => new UserGetDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Profile = user.Profile
            }));
            return new PagedList<UserGetDTO>(userDTOs, users.CurrentPage, users.PageSize, users.TotalCount);
        }

        public async Task<UserGetDTO> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                throw new NotFoundException("Usuário não encontrado");
            }
            return new UserGetDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Profile = user.Profile
            };
        }

        public async Task<UserGetDTO> GetUserByEmail(string email)
        {
            var user = await _userRepository.GetUserByEmail(email);
            if (user == null)
            {
                throw new NotFoundException("Usuário não encontrado");
            }
            return new UserGetDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Profile = user.Profile
            };
        }

        public async Task<UserGetDTO> UpdateAsync(int userId, UserPutDTO userPutDTO)
        {
            var existingUser = await _userRepository.GetByIdAsync(userId);
            if (existingUser == null)
            {
                throw new NotFoundException("Usuário não encontrado");
            }

            existingUser.Name = userPutDTO.Name;
            existingUser.Email = userPutDTO.Email;
            var updatedUser = await _userRepository.UpdateAsync(existingUser);
            return new UserGetDTO
            {
                Id = updatedUser.Id,
                Name = updatedUser.Name,
                Email = updatedUser.Email,
                Profile = updatedUser.Profile
            };
        }
    }
}
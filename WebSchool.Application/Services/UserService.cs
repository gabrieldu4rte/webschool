using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using WebSchool.Application.DTOs.User;
using WebSchool.Application.Exceptions;
using WebSchool.Application.Interfaces;
using WebSchool.Domain.Entities;
using WebSchool.Domain.Interfaces;

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
            using var hmac = new HMACSHA512();
            byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userPostDTO.Password));
            byte[] passwordSalt = hmac.Key;

            var newUser = new User
            {
                Name = userPostDTO.Name,
                Email = userPostDTO.Email,
                IsDeleted = false,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Profile = "Aluno"
            };
            var addedUser = await _userRepository.AddAsync(newUser);
            return new UserGetDTO
            {
                Id = addedUser.Id,
                Name = addedUser.Name,
                Email = addedUser.Email
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
                Email = deletedUser.Email
            };
        }

        public async Task<List<UserGetDTO>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            var userDTOs = new List<UserGetDTO>();
            userDTOs.AddRange(users.Select(user => new UserGetDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            }));
            return userDTOs;
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
                Email = user.Email
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
                Email = updatedUser.Email
            };
        }
    }
}
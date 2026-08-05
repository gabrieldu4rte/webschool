using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebSchool.Domain.Entities;
using WebSchool.Domain.Interfaces;
using WebSchool.Domain.Pagination;
using WebSchool.Infra.Data.Context;
using WebSchool.Infra.Data.Helpers;

namespace WebSchool.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<User> AddAsync(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> DeleteAsync(int id)
        {
            var user = await _context.User.Where(x => x.IsDeleted == false && x.Id == id).FirstOrDefaultAsync();
            if (user == null)
            {
                return null;
            }

            user.IsDeleted = true;
            _context.User.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> ExistUserAsync()
        {
            return await _context.User.AnyAsync(x => x.IsDeleted == false);
        }

        public async Task<PagedList<User>> GetAllAsync(int pageNumber, int pageSize)
        {
            var query = _context.User.Where(x => x.IsDeleted == false).AsNoTracking();
            return await PaginationHelper.CreateAsync(query, pageNumber, pageSize);
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.User.Where(x => x.IsDeleted == false && x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.User.FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower() && u.IsDeleted == false);
        }

        public async Task<User> UpdateAsync(User user)
        {
            _context.User.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> UserExists(string email)
        {
            return await _context.User.AnyAsync(u => u.Email.ToLower() == email.ToLower() && u.IsDeleted == false);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebSchool.Domain.Entities;
using WebSchool.Domain.Interfaces;
using WebSchool.Infra.Data.Context;

namespace WebSchool.Infra.Data.Repositories
{
    public class TuitionRepository : ITuitionRepository
    {
        private readonly ApplicationDbContext _context;
        public async Task<Tuition> AddAsync(Tuition tuition)
        {
            _context.Tuition.Add(tuition);
            await _context.SaveChangesAsync();
            return tuition;
        }

        public async Task<Tuition> DeleteAsync(int id)
        {
            var tuition = await _context.Tuition.Where(x => x.IsDeleted == false && x.Id == id).FirstOrDefaultAsync();
            if (tuition == null)
            {
                return null;
            }

            tuition.IsDeleted = true;
            _context.Tuition.Update(tuition);
            await _context.SaveChangesAsync();
            return tuition;
        }

        public async Task<List<Tuition>> GetAllAsync()
        {
            return await _context.Tuition.Where(x => x.IsDeleted == false).ToListAsync();
        }

        public async Task<Tuition> GetByIdAsync(int id)
        {
            return await _context.Tuition.Where(x => x.IsDeleted == false && x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Tuition> UpdateAsync(Tuition tuition)
        {
            _context.Tuition.Update(tuition);
            await _context.SaveChangesAsync();
            return tuition;
        }
    }
}

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
    public class SchoolClassRepository : ISchoolClassRepository
    {
        private readonly ApplicationDbContext _context;
        public SchoolClassRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SchoolClass> AddAsync(SchoolClass schoolclass)
        {
            _context.SchoolClass.Add(schoolclass);
            await _context.SaveChangesAsync();
            return schoolclass;
        }

        public async Task<SchoolClass> DeleteAsync(int id)
        {
            var schoolclass = await _context.SchoolClass.Where(x => x.IsDeleted == false && x.Id == id).FirstOrDefaultAsync();
            if (schoolclass == null)
            {
                return null;
            }

            schoolclass.IsDeleted = true;
            _context.SchoolClass.Update(schoolclass);
            await _context.SaveChangesAsync();
            return schoolclass;
        }

        public async Task<PagedList<SchoolClass>> GetAllAsync( int pageNumber, int pageSize)
        {
            var query= _context.SchoolClass.Include(x => x.Course).Where(x => x.IsDeleted == false).AsNoTracking();
            return await PaginationHelper.CreateAsync(query, pageNumber, pageSize);
        }

        public async Task<SchoolClass> GetByIdAsync(int id)
        {
            return await _context.SchoolClass.Include(x => x.Course).Where(x => x.IsDeleted == false && x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<PagedList<SchoolClass>> GetSchoolClassesByUser(int userId, int pageNumber, int pageSize)
        {
            var query = _context.SchoolClass
                .Include(s => s.Course)
                .Where(s => s.IsDeleted == false && s.Tuitions.Any(t => t.UserId == userId))
                .AsNoTracking();
            return await PaginationHelper.CreateAsync(query, pageNumber, pageSize);
        }

        public async Task<SchoolClass> UpdateAsync(SchoolClass schoolclass)
        {
            _context.SchoolClass.Update(schoolclass);
            await _context.SaveChangesAsync();
            return schoolclass;
        }
    }
}

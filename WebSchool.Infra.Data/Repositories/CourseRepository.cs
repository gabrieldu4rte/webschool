using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using WebSchool.Domain.Entities;
using WebSchool.Domain.Interfaces;
using WebSchool.Infra.Data.Context;

namespace WebSchool.Infra.Data.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context;

        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Course> AddAsync(Course course)
        {
            _context.Course.Add(course);
            await _context.SaveChangesAsync();
            return course;
        }

        public async Task<Course> DeleteAsync(int id)
        {
            var course = await _context.Course.Where(x => x.IsDeleted == false && x.Id == id).FirstOrDefaultAsync();
            if (course == null) {
                return null;
             }

            course.IsDeleted = true;
            _context.Course.Update(course);
            await _context.SaveChangesAsync();
            return course;
        }

        public async Task<List<Course>> GetAllAsync()
        {
            return await _context.Course.Where(x => x.IsDeleted == false).ToListAsync();
        }

        public async Task<Course> GetByIdAsync(int id)
        {
            return await _context.Course.Where(x => x.IsDeleted == false && x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Course> UpdateAsync(Course course)
        {
            _context.Course.Update(course);
            await _context.SaveChangesAsync();
            return course;
        }
    }
}

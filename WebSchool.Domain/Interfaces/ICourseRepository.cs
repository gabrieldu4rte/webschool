using System;
using System.Collections.Generic;
using System.Text;
using WebSchool.Domain.Entities;

namespace WebSchool.Domain.Interfaces
{
    public interface ICourseRepository
    {
        Task<Course> GetByIdAsync(int id);
        Task<List<Course>> GetAllAsync();

        Task<Course> AddAsync(Course course);
        Task<Course> UpdateAsync(Course course);
        Task<Course> DeleteAsync(int id);
    }
}

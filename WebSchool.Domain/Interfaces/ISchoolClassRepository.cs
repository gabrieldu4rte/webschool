using System;
using System.Collections.Generic;
using System.Text;
using WebSchool.Domain.Entities;

namespace WebSchool.Domain.Interfaces
{
    public interface ISchoolClassRepository
    {
        Task<SchoolClass> GetByIdAsync(int id);
        Task<List<SchoolClass>> GetAllAsync();

        Task<SchoolClass> AddAsync(SchoolClass schoolclass);
        Task<SchoolClass> UpdateAsync(SchoolClass schoolclass);
        Task<SchoolClass> DeleteAsync(int id);
        Task<List<SchoolClass>> GetSchoolClassesByUser(int userId);
    }
}

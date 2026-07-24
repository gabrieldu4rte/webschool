using System;
using System.Collections.Generic;
using System.Text;
using WebSchool.Domain.Entities;
using WebSchool.Domain.Pagination;

namespace WebSchool.Domain.Interfaces
{
    public interface ISchoolClassRepository
    {
        Task<SchoolClass> GetByIdAsync(int id);
        Task<PagedList<SchoolClass>> GetAllAsync(int pageNumber, int pageSize);

        Task<SchoolClass> AddAsync(SchoolClass schoolclass);
        Task<SchoolClass> UpdateAsync(SchoolClass schoolclass);
        Task<SchoolClass> DeleteAsync(int id);
        Task<PagedList<SchoolClass>> GetSchoolClassesByUser(int userId, int pageNumber, int pageSize);
    }
}

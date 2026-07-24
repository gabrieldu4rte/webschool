using System;
using System.Collections.Generic;
using System.Text;
using WebSchool.Application.DTOs.SchoolClass;
using WebSchool.Domain.Entities;
using WebSchool.Domain.Pagination;

namespace WebSchool.Application.Interfaces
{
    public interface ISchoolClassService
    {
        Task<SchoolClassGetDetailDTO> GetByIdAsync(int id);
        Task<PagedList<SchoolClassGetDetailDTO>> GetAllAsync(int pageNumber, int pageSize);

        Task<SchoolClassGetDTO> AddAsync(SchoolClassPostDTO schoolclass);
        Task<SchoolClassGetDTO> UpdateAsync(SchoolClassPutDTO schoolclass);
        Task<SchoolClassGetDTO> DeleteAsync(int id);
        Task<PagedList<SchoolClassGetDetailDTO>> GetSchoolClassesByUser(int userId, int pageNumber, int pageSize);
        
    }
}

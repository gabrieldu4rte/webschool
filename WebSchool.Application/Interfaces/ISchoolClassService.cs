using System;
using System.Collections.Generic;
using System.Text;
using WebSchool.Application.DTOs.SchoolClass;
using WebSchool.Domain.Entities;

namespace WebSchool.Application.Interfaces
{
    public interface ISchoolClassService
    {
        Task<SchoolClassGetDetailDTO> GetByIdAsync(int id);
        Task<List<SchoolClassGetDetailDTO>> GetAllAsync();

        Task<SchoolClassGetDTO> AddAsync(SchoolClassPostDTO schoolclass);
        Task<SchoolClassGetDTO> UpdateAsync(SchoolClassPutDTO schoolclass);
        Task<SchoolClassGetDTO> DeleteAsync(int id);
        Task<List<SchoolClassGetDetailDTO>> GetSchoolClassesByUser(int userId);
        
    }
}

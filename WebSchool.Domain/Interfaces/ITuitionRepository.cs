using System;
using System.Collections.Generic;
using System.Text;
using WebSchool.Domain.Entities;
using WebSchool.Domain.Pagination;

namespace WebSchool.Domain.Interfaces
{
    public interface ITuitionRepository
    {
        Task<Tuition> GetByIdAsync(int id);
        Task<PagedList<Tuition>> GetAllAsync(int pageNumber, int pageSize);

        Task<Tuition> AddAsync(Tuition tuition);
        Task<Tuition> UpdateAsync(Tuition tuition);
        Task<Tuition> DeleteAsync(int id);
    }
}

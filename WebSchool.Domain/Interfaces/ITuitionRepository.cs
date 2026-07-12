using System;
using System.Collections.Generic;
using System.Text;
using WebSchool.Domain.Entities;

namespace WebSchool.Domain.Interfaces
{
    public interface ITuitionRepository
    {
        Task<Tuition> GetByIdAsync(int id);
        Task<List<Tuition>> GetAllAsync();

        Task<Tuition> AddAsync(Tuition tuition);
        Task<Tuition> UpdateAsync(Tuition tuition);
        Task<Tuition> DeleteAsync(int id);
    }
}

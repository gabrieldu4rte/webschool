using System;
using System.Collections.Generic;
using System.Text;
using WebSchool.Application.DTOs.Tuition;
using WebSchool.Domain.Entities;

namespace WebSchool.Application.Interfaces
{
    public interface ITuitionService
    {
        Task<TuitionGetDetailDTO> GetByIdAsync(int id);
        Task<List<TuitionGetDetailDTO>> GetAllAsync();

        Task<TuitionGetDTO> AddAsync(TuitionPostDTO tuitionPostDTO);
        Task<TuitionGetDTO> UpdateAsync(TuitionPutDTO tuitionPutDTO);
        Task<TuitionGetDTO> DeleteAsync(int id);
    }
}

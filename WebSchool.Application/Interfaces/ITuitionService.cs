using System;
using System.Collections.Generic;
using System.Text;
using WebSchool.Application.DTOs.Tuition;
using WebSchool.Domain.Entities;
using WebSchool.Domain.Pagination;

namespace WebSchool.Application.Interfaces
{
    public interface ITuitionService
    {
        Task<TuitionGetDetailDTO> GetByIdAsync(int id);
        Task<PagedList<TuitionGetDetailDTO>> GetAllAsync(int pageNumber, int pageSize);
        Task<TuitionGetDTO> AddAsync(TuitionPostDTO tuitionPostDTO);
        Task<TuitionGetDTO> UpdateAsync(TuitionPutDTO tuitionPutDTO);
        Task<TuitionGetDTO> DeleteAsync(int id);
    }
}

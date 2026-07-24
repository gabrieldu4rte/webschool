using WebSchool.Application.DTOs.Course;
using WebSchool.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using WebSchool.Domain.Pagination;

namespace WebSchool.Application.Interfaces
{
    public interface ICourseService
    {
        Task<CourseGetDTO> GetByIdAsync(int id);
        Task<PagedList<CourseGetDTO>> GetAllAsync(int pageNumber, int pageSize);

        Task<CourseGetDTO> AddAsync(CoursePostDTO coursePostDTO);
        Task<CourseGetDTO> UpdateAsync(CoursePutDTO coursePutDTO);
        Task<CourseGetDTO> DeleteAsync(int id);
    }
}
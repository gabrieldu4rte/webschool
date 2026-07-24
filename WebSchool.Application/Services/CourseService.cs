using System;
using System.Collections.Generic;
using System.Text;
using WebSchool.Application.DTOs.Course;
using WebSchool.Application.DTOs.SchoolClass;
using WebSchool.Application.Exceptions;
using WebSchool.Application.Interfaces;
using WebSchool.Domain.Entities;
using WebSchool.Domain.Interfaces;
using WebSchool.Domain.Pagination;

namespace WebSchool.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<CourseGetDTO> AddAsync(CoursePostDTO coursePostDTO)
        {
            var course = new Course
            {
                Name = coursePostDTO.Name,
                Description = coursePostDTO.Description,
            };

            var createdCourse = await _courseRepository.AddAsync(course);
            return new CourseGetDTO
            {
                Id = createdCourse.Id,
                Name = createdCourse.Name,
                Description = createdCourse.Description,
            };
        }

        public async Task<CourseGetDTO> DeleteAsync(int id)
        {
            var deletedCourse = await _courseRepository.DeleteAsync(id);
            if (deletedCourse == null)
                throw new NotFoundException("Curso não encontrado");
            return new CourseGetDTO
            {
                Id = deletedCourse.Id,
                Name = deletedCourse.Name,
                Description = deletedCourse.Description,
            };
        }

        public async Task<PagedList<CourseGetDTO>> GetAllAsync(int pageNumber, int pageSize)
        {
            var courses = await _courseRepository.GetAllAsync(pageNumber, pageSize);
            var courseGetDTOs = new List<CourseGetDTO>();
            foreach (var course in courses)
            {
                courseGetDTOs.Add(new CourseGetDTO
                {
                    Id = course.Id,
                    Name = course.Name,
                    Description = course.Description,
                });
            }
            return new PagedList<CourseGetDTO>(courseGetDTOs, courses.CurrentPage, courses.PageSize, courses.TotalCount);
        }

        public async Task<CourseGetDTO> GetByIdAsync(int id)
        {
            var course = await _courseRepository.GetByIdAsync(id);
            if (course == null)
                throw new NotFoundException("Curso não encontrado");
            return new CourseGetDTO
            {
                Id = course.Id,
                Name = course.Name,
                Description = course.Description,
            };
        }

        public async Task<CourseGetDTO> UpdateAsync(CoursePutDTO coursePutDTO)
        {
            var course = await _courseRepository.GetByIdAsync(coursePutDTO.Id);
            if (course == null)
                throw new NotFoundException("Curso não encontrado");

            course.Name = coursePutDTO.Name;
            course.Description = coursePutDTO.Description;

            var updatedCourse = await _courseRepository.UpdateAsync(course);
            return new CourseGetDTO
            {
                Id = updatedCourse.Id,
                Name = updatedCourse.Name,
                Description = updatedCourse.Description,
            };
        }
    }
}
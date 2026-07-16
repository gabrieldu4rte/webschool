using WebSchool.Domain.Entities;
using WebSchool.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using WebSchool.Application.Interfaces;
using WebSchool.Application.DTOs.SchoolClass;
using WebSchool.Application.DTOs.Course;

namespace WebSchool.Application.Services
{
    public class SchoolClassService : ISchoolClassService
    {
        private readonly ISchoolClassRepository _schoolClassRepository;

        public SchoolClassService(ISchoolClassRepository schoolClassRepository)
        {
            _schoolClassRepository = schoolClassRepository;
        }

        public async Task<SchoolClassGetDTO> AddAsync(SchoolClassPostDTO schoolclass)
        {
            var newSchoolClass = new SchoolClass
            {
                Name = schoolclass.Name,
                Description = schoolclass.Description,
                CourseId = schoolclass.CourseId
            };

            var addedSchoolClass = await _schoolClassRepository.AddAsync(newSchoolClass);

            return new SchoolClassGetDTO
            {
                Id = addedSchoolClass.Id,
                Name = addedSchoolClass.Name,
                Description = addedSchoolClass.Description,
                CourseId = addedSchoolClass.CourseId
            };
        }

        public async Task<SchoolClassGetDTO> DeleteAsync(int id)
        {
            var deletedSchoolClass = await _schoolClassRepository.DeleteAsync(id);
            if (deletedSchoolClass == null)
                return null;
            return new SchoolClassGetDTO
            {
                Id = deletedSchoolClass.Id,
                Name = deletedSchoolClass.Name,
                Description = deletedSchoolClass.Description,
                CourseId = deletedSchoolClass.CourseId
            };
        }

        public async Task<List<SchoolClassGetDetailDTO>> GetAllAsync()
        {
            var schoolClasses = await _schoolClassRepository.GetAllAsync();
            var schoolClassGetDetailDTOs = new List<SchoolClassGetDetailDTO>();
            schoolClassGetDetailDTOs.AddRange(schoolClasses.Select(sc => new SchoolClassGetDetailDTO
            {
                Id = sc.Id,
                Name = sc.Name,
                Description = sc.Description,
                Course = new CourseGetDTO
                {
                    Id = sc.Course.Id,
                    Name = sc.Course.Name,
                    Description = sc.Course.Description
                }
            }));
            return schoolClassGetDetailDTOs;
        }

        public async Task<SchoolClassGetDetailDTO> GetByIdAsync(int id)
        {
            var schoolClass = await _schoolClassRepository.GetByIdAsync(id);
            if (schoolClass == null)
                return null;
            return new SchoolClassGetDetailDTO
            {
                Id = schoolClass.Id,
                Name = schoolClass.Name,
                Description = schoolClass.Description,
                Course = new CourseGetDTO
                {
                    Id = schoolClass.Course.Id,
                    Name = schoolClass.Course.Name,
                    Description = schoolClass.Course.Description
                }
            };
        }

        public async Task<SchoolClassGetDTO> UpdateAsync(SchoolClassPutDTO schoolclass)
        {
            var schoolClass = new SchoolClass
            {
                Id = schoolclass.Id,
                Name = schoolclass.Name,
                Description = schoolclass.Description,
                CourseId = schoolclass.CourseId
            };
            var updatedSchoolClass = await _schoolClassRepository.UpdateAsync(schoolClass);
            if (updatedSchoolClass == null)
                return null;
            return new SchoolClassGetDTO
            {
                Id = updatedSchoolClass.Id,
                Name = updatedSchoolClass.Name,
                Description = updatedSchoolClass.Description,
                CourseId = updatedSchoolClass.CourseId
            };
        }
    }
}
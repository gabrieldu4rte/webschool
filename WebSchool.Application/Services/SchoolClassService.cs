using WebSchool.Domain.Entities;
using WebSchool.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using WebSchool.Application.Interfaces;
using WebSchool.Application.DTOs.SchoolClass;
using WebSchool.Application.DTOs.Course;
using WebSchool.Application.Exceptions;

namespace WebSchool.Application.Services
{
    public class SchoolClassService : ISchoolClassService
    {
        private readonly ISchoolClassRepository _schoolClassRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IUserRepository _userRepository;

        public SchoolClassService(ISchoolClassRepository schoolClassRepository, ICourseRepository courseRepository, IUserRepository userRepository)
        {
            _schoolClassRepository = schoolClassRepository;
            _courseRepository = courseRepository;
            _userRepository = userRepository;
        }

        public async Task<SchoolClassGetDTO> AddAsync(SchoolClassPostDTO schoolClassPostDTO)
        {
            var course = await _courseRepository.GetByIdAsync(schoolClassPostDTO.CourseId);
            if (course == null)
                throw new NotFoundException("Curso não encontrado");

            var newSchoolClass = new SchoolClass
            {
                Name = schoolClassPostDTO.Name,
                Description = schoolClassPostDTO.Description,
                CourseId = schoolClassPostDTO.CourseId
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
                throw new NotFoundException("Turma não encontrada");
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
                throw new NotFoundException("Turma não encontrada");
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

        public async Task<List<SchoolClassGetDetailDTO>> GetSchoolClassesByUser(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                throw new NotFoundException("Usuário não encontrado");
            var schoolClasses = await _schoolClassRepository.GetSchoolClassesByUser(userId);
            var schoolClassGetDetailDTO = new List<SchoolClassGetDetailDTO>();
            schoolClassGetDetailDTO.AddRange(schoolClasses.Select(schoolClass => new SchoolClassGetDetailDTO 
            { 
                Id = schoolClass.Id, 
                Name = schoolClass.Name, 
                Description = schoolClass.Description,
                Course = new CourseGetDTO
                {
                    Id = schoolClass.Course.Id,
                    Name= schoolClass.Course.Name,
                    Description= schoolClass.Course.Description
                }
            }));
            return schoolClassGetDetailDTO;
        }

        public async Task<SchoolClassGetDTO> UpdateAsync(SchoolClassPutDTO schoolClassPutDTO)
        {
            var schoolClass = await _schoolClassRepository.GetByIdAsync(schoolClassPutDTO.Id);
            if (schoolClass == null)
            {
                throw new NotFoundException("Turma não encontrada");
            }
            var course = await _courseRepository.GetByIdAsync(schoolClassPutDTO.CourseId);
            if (course == null)
                throw new NotFoundException("Curso não encontrado");

            schoolClass.Id = schoolClassPutDTO.Id;
            schoolClass.Name = schoolClassPutDTO.Name;
            schoolClass.Description = schoolClassPutDTO.Description;
            schoolClass.CourseId = schoolClassPutDTO.CourseId;

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
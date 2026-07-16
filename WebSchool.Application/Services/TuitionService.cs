using System;
using System.Collections.Generic;
using System.Text;
using WebSchool.Application.DTOs.SchoolClass;
using WebSchool.Application.DTOs.Tuition;
using WebSchool.Application.DTOs.User;
using WebSchool.Application.Interfaces;
using WebSchool.Domain.Entities;
using WebSchool.Domain.Interfaces;

namespace WebSchool.Application.Services
{
    public class TuitionService : ITuitionService
    {
        private readonly ITuitionRepository _tuitionRepository;

        public TuitionService(ITuitionRepository tuitionRepository)
        {
            _tuitionRepository = tuitionRepository;
        }

        public async Task<TuitionGetDTO> AddAsync(TuitionPostDTO tuitionPostDTO)
        {
            var tuition = new Tuition
            {
                UserId = tuitionPostDTO.UserId,
                SchoolClassId = tuitionPostDTO.SchoolClassId,
                TuitionDate = DateTime.UtcNow,
                ExpireDate = tuitionPostDTO.ExpireDate,
                Active = true,
            };
            var addedTuition = await _tuitionRepository.AddAsync(tuition);
            return new TuitionGetDTO
            {
                Id = addedTuition.Id,
                UserId = addedTuition.UserId,
                SchoolClassId = addedTuition.SchoolClassId,
                TuitionDate = addedTuition.TuitionDate,
                ExpireDate = addedTuition.ExpireDate,
                Active = addedTuition.Active
            };

        }

        public async Task<TuitionGetDTO> DeleteAsync(int id)
        {
            var deletedTuition = await _tuitionRepository.DeleteAsync(id);
            if (deletedTuition == null)
                return null;
            return new TuitionGetDTO
            {
                Id = deletedTuition.Id,
                UserId = deletedTuition.UserId,
                SchoolClassId = deletedTuition.SchoolClassId,
                TuitionDate = deletedTuition.TuitionDate,
                ExpireDate = deletedTuition.ExpireDate,
                Active = deletedTuition.Active
            };
        }

        public async Task<List<TuitionGetDetailDTO>> GetAllAsync()
        {
            var tuitions = await _tuitionRepository.GetAllAsync();
            var tuitionGetDetailDTO = new List<TuitionGetDetailDTO>();
            tuitionGetDetailDTO.AddRange(tuitions.Select(tuition => new TuitionGetDetailDTO
            {
                Id = tuition.Id,
                TuitionDate = tuition.TuitionDate,
                ExpireDate = tuition.ExpireDate,
                Active = tuition.Active,
                User = new UserGetDTO
                {
                    Id = tuition.User.Id,
                    Name = tuition.User.Name,
                    Email = tuition.User.Email,
                },
                SchoolClass = new SchoolClassGetDTO
                {
                    Id = tuition.SchoolClass.Id,
                    Name = tuition.SchoolClass.Name,
                    Description = tuition.SchoolClass.Description
                }
            }));
            return tuitionGetDetailDTO;
        }

        public async Task<TuitionGetDetailDTO> GetByIdAsync(int id)
        {
            var tuition = await _tuitionRepository.GetByIdAsync(id);
            if (tuition == null)
                return null;
            return new TuitionGetDetailDTO
            {
                Id = tuition.Id,
                TuitionDate = tuition.TuitionDate,
                ExpireDate = tuition.ExpireDate,
                Active = tuition.Active,
                User = new UserGetDTO
                {
                    Id = tuition.User.Id,
                    Name = tuition.User.Name,
                    Email = tuition.User.Email,
                },
                SchoolClass = new SchoolClassGetDTO
                {
                    Id = tuition.SchoolClass.Id,
                    Name = tuition.SchoolClass.Name,
                    Description = tuition.SchoolClass.Description
                }
            };
        }

        public async Task<TuitionGetDTO> UpdateAsync(TuitionPutDTO tuitionPutDTO)
        {
            var tuition = new Tuition
            {
                Id = tuitionPutDTO.Id,
                SchoolClassId = tuitionPutDTO.SchoolClassId,
                ExpireDate = tuitionPutDTO.ExpireDate
            };
            var updatedTuition = await _tuitionRepository.UpdateAsync(tuition);
            if (updatedTuition == null)
                return null;
            return new TuitionGetDTO
            {
                Id = updatedTuition.Id,
                UserId = updatedTuition.UserId,
                SchoolClassId = updatedTuition.SchoolClassId,
                TuitionDate = updatedTuition.TuitionDate,
                ExpireDate = updatedTuition.ExpireDate,
                Active = updatedTuition.Active
            };
        }
    }
}

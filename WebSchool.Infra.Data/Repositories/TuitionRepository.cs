using System;
using System.Collections.Generic;
using System.Text;
using WebSchool.Domain.Entities;
using WebSchool.Domain.Interfaces;

namespace WebSchool.Infra.Data.Repositories
{
    public class TuitionRepository : ITuitionRepository
    {
        public Task<Tuition> AddAsync(Tuition tuition)
        {
            throw new NotImplementedException();
        }

        public Task<Tuition> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Tuition>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Tuition> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Tuition> UpdateAsync(Tuition tuition)
        {
            throw new NotImplementedException();
        }
    }
}

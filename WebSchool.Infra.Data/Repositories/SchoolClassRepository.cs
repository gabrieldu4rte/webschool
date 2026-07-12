using System;
using System.Collections.Generic;
using System.Text;
using WebSchool.Domain.Entities;
using WebSchool.Domain.Interfaces;

namespace WebSchool.Infra.Data.Repositories
{
    public class SchoolClassRepository : ISchoolClassRepository
    {
        public Task<SchoolClass> AddAsync(SchoolClass schoolclass)
        {
            throw new NotImplementedException();
        }

        public Task<SchoolClass> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<SchoolClass>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<SchoolClass> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SchoolClass> UpdateAsync(SchoolClass schoolclass)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using WebSchool.Domain.Entities;
using WebSchool.Domain.Interfaces;

namespace WebSchool.Infra.Data.Repositories
{
    public class NoteRepository : INoteRepository
    {
        public Task<Note> AddAsync(Note note)
        {
            throw new NotImplementedException();
        }

        public Task<Note> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Note>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Note> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Note> UpdateAsync(Note note)
        {
            throw new NotImplementedException();
        }
    }
}

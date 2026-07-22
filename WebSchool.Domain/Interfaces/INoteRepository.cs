using System;
using System.Collections.Generic;
using System.Text;
using WebSchool.Domain.Entities;

namespace WebSchool.Domain.Interfaces
{
    public interface INoteRepository
    {
        Task<Note> GetByIdAsync(int id);
        Task<List<Note>> GetAllAsync();

        Task<Note> AddAsync(Note note);
        Task<Note> UpdateAsync(Note note);
        Task<Note> DeleteAsync(int id);
        Task<List<Note>> GetNotesBySchoolClassUser(int schoolClassId, int userId);
    }
}

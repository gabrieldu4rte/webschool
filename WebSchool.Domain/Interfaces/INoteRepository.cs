using System;
using System.Collections.Generic;
using System.Text;
using WebSchool.Domain.Entities;
using WebSchool.Domain.Pagination;

namespace WebSchool.Domain.Interfaces
{
    public interface INoteRepository
    {
        Task<Note> GetByIdAsync(int id);
        Task<PagedList<Note>> GetAllAsync(int pageNumber, int pageSize);
        Task<Note> AddAsync(Note note);
        Task<Note> UpdateAsync(Note note);
        Task<Note> DeleteAsync(int id);
        Task<PagedList<Note>> GetNotesBySchoolClassUser(int schoolClassId, int userId, int pageNumber, int pageSize);
    }
}

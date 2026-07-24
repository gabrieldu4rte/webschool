using System;
using System.Collections.Generic;
using System.Text;
using WebSchool.Application.DTOs.Note;
using WebSchool.Domain.Entities;
using WebSchool.Domain.Pagination;

namespace WebSchool.Application.Interfaces
{
    public interface INoteService
    {
        Task<NoteGetDTO> GetByIdAsync(int id);
        Task<PagedList<NoteGetDTO>> GetAllAsync(int pageNumber, int pageSize);

        Task<NoteGetDTO> AddAsync(NotePostDTO note);
        Task<NoteGetDTO> UpdateAsync(NotePutDTO note);
        Task<NoteGetDTO> DeleteAsync(int id);
        Task<PagedList<NoteGetDTO>> GetNotesBySchoolClassUser(int schoolClassId, int userId, int pageNumber, int pageSize);
    }
}

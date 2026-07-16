using System;
using System.Collections.Generic;
using System.Text;
using WebSchool.Application.DTOs.Note;
using WebSchool.Domain.Entities;

namespace WebSchool.Application.Interfaces
{
    public interface INoteService
    {
        Task<NoteGetDTO> GetByIdAsync(int id);
        Task<List<NoteGetDTO>> GetAllAsync();

        Task<NoteGetDTO> AddAsync(NotePostDTO note);
        Task<NoteGetDTO> UpdateAsync(NotePutDTO note);
        Task<NoteGetDTO> DeleteAsync(int id);
    }
}

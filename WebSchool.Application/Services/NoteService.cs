using System;
using System.Collections.Generic;
using System.Text;
using WebSchool.Application.DTOs.Note;
using WebSchool.Application.Exceptions;
using WebSchool.Application.Interfaces;
using WebSchool.Domain.Entities;
using WebSchool.Domain.Interfaces;

namespace WebSchool.Application.Services
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;
        private readonly ITuitionRepository _tuitionRepository;

        public NoteService(INoteRepository noteRepository, ITuitionRepository tuitionRepository)
        {
            _noteRepository = noteRepository;
            _tuitionRepository = tuitionRepository;
        }

        public async Task<NoteGetDTO> AddAsync(NotePostDTO notePostDTO)
        {
            if (await _tuitionRepository.GetByIdAsync(notePostDTO.TuitionId) == null)
                throw new NotFoundException("Matrícula não encontrada");
            var note = new Note
            {
                TuitionId = notePostDTO.TuitionId,
                NoteValue = notePostDTO.NoteValue,
                Aproved = notePostDTO.NoteValue >= 60,
                NoteDate = DateTime.UtcNow
            };
            var addedNote = await _noteRepository.AddAsync(note);
            return new NoteGetDTO
            {
                Id = addedNote.Id,
                TuitionId = addedNote.TuitionId,
                NoteValue = addedNote.NoteValue,
                Aproved = addedNote.Aproved,
                NoteDate = addedNote.NoteDate,
            };
        }

        public async Task<NoteGetDTO> DeleteAsync(int id)
        {
            var deletedNote = await _noteRepository.DeleteAsync(id);
            if (deletedNote == null)
                throw new NotFoundException("Nota não encontrada");
            return new NoteGetDTO
            {
                Id = deletedNote.Id,
                TuitionId = deletedNote.TuitionId,
                NoteValue = deletedNote.NoteValue,
                Aproved = deletedNote.Aproved,
                NoteDate = deletedNote.NoteDate
            };
        }

        public async Task<List<NoteGetDTO>> GetAllAsync()
        {
            var notes = await _noteRepository.GetAllAsync();
            var noteGetDTOs = new List<NoteGetDTO>();
            foreach (var note in notes)
            {
                noteGetDTOs.Add(new NoteGetDTO
                {
                    Id = note.Id,
                    TuitionId = note.TuitionId,
                    NoteValue = note.NoteValue,
                    Aproved = note.Aproved,
                    NoteDate = note.NoteDate
                });
            }
            return noteGetDTOs;
        }

        public async Task<NoteGetDTO> GetByIdAsync(int id)
        {
            var note = await _noteRepository.GetByIdAsync(id);
            if (note == null)
                throw new NotFoundException("Nota não encontrada");
            return new NoteGetDTO
            {
                Id = note.Id,
                TuitionId = note.TuitionId,
                NoteValue = note.NoteValue,
                Aproved = note.Aproved,
                NoteDate = note.NoteDate
            };
        }

        public async Task<List<NoteGetDTO>> GetNotesBySchoolClassUser(int schoolClassId, int userId)
        {
            var notes = await _noteRepository.GetNotesBySchoolClassUser(schoolClassId, userId);
            var noteDTOs = new List<NoteGetDTO>();
            foreach (var note in notes) 
            {
                noteDTOs.Add(new NoteGetDTO
                {
                    Id = note.Id,
                    TuitionId = note.TuitionId,
                    NoteValue = note.NoteValue,
                    Aproved = note.Aproved,
                    NoteDate = note.NoteDate
                });
            }
            return noteDTOs;
        }

        public async Task<NoteGetDTO> UpdateAsync(NotePutDTO notePutDTO)
        {
            var note = await _noteRepository.GetByIdAsync(notePutDTO.Id);
            if (note == null)
                throw new NotFoundException("Nota não encontrada");

            note.NoteValue = notePutDTO.NoteValue;
            note.Aproved = notePutDTO.NoteValue >= 60;

            var updatedNote = await _noteRepository.UpdateAsync(note);
            return new NoteGetDTO
            {
                Id = updatedNote.Id,
                TuitionId = updatedNote.TuitionId,
                NoteValue = updatedNote.NoteValue,
                Aproved = updatedNote.Aproved,
                NoteDate = updatedNote.NoteDate
            };
        }
    }
}
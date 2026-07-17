using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebSchool.Domain.Entities;
using WebSchool.Domain.Interfaces;
using WebSchool.Infra.Data.Context;

namespace WebSchool.Infra.Data.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly ApplicationDbContext _context;

        public NoteRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Note> AddAsync(Note note)
        {
            _context.Note.Add(note);
            await _context.SaveChangesAsync();
            return note;
        }

        public async Task<Note> DeleteAsync(int id)
        {
            var note = await _context.Note.Where(x => x.IsDeleted == false && x.Id == id).FirstOrDefaultAsync();
            if (note == null)
            {
                return null;
            }

            note.IsDeleted = true;
            _context.Note.Update(note);
            await _context.SaveChangesAsync();
            return note;
        }

        public async Task<List<Note>> GetAllAsync()
        {
            return await _context.Note.Where(x => x.IsDeleted == false).ToListAsync();
        }

        public async Task<Note> GetByIdAsync(int id)
        {
            return await _context.Note.Where(x => x.IsDeleted == false && x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Note> UpdateAsync(Note note)
        {
            _context.Note.Update(note);
            await _context.SaveChangesAsync();
            return note;
        }
    }
}

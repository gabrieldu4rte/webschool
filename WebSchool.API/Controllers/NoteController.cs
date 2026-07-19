using WebSchool.Application.Interfaces;
using WebSchool.Application.DTOs.Note;
using Microsoft.AspNetCore.Mvc;

namespace WebSchool.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoteController : Controller
    {
        private readonly INoteService _noteService;

        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateNote(NotePostDTO notePostDTO)
        {
            var note = await _noteService.AddAsync(notePostDTO);
            return Ok(new { message = "Nota criada com sucesso." });
        }

        [HttpPut]
        public async Task<ActionResult> UpdateNote(NotePutDTO notePutDTO)
        {
            var note = await _noteService.UpdateAsync(notePutDTO);
            return Ok(new { message = "Nota atualizada com sucesso." });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteNote(int id)
        {
            var note = await _noteService.DeleteAsync(id);
            return Ok(new { message = "Nota excluída com sucesso." });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetNoteById(int id)
        {
            var note = await _noteService.GetByIdAsync(id);
            return Ok(note);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllNotes()
        {
            var notes = await _noteService.GetAllAsync();
            return Ok(notes);
        }
    }
}

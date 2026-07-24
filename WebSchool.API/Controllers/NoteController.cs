using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebSchool.API.Extensions;
using WebSchool.API.Models;
using WebSchool.Application.DTOs.Note;
using WebSchool.Application.Interfaces;
using WebSchool.Domain.Entities;
using WebSchool.Infra.Ioc;

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
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult> CreateNote(NotePostDTO notePostDTO)
        {
            var note = await _noteService.AddAsync(notePostDTO);
            return Ok(new { message = "Nota criada com sucesso." });
        }

        [HttpPut]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult> UpdateNote(NotePutDTO notePutDTO)
        {
            var note = await _noteService.UpdateAsync(notePutDTO);
            return Ok(new { message = "Nota atualizada com sucesso." });
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult> DeleteNote(int id)
        {
            var note = await _noteService.DeleteAsync(id);
            return Ok(new { message = "Nota excluída com sucesso." });
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult> GetNoteById(int id)
        {
            var note = await _noteService.GetByIdAsync(id);
            return Ok(note);
        }

        [HttpGet]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult> GetAllNotes([FromQuery] PaginationParams paginationParams)
        {
            var notes = await _noteService.GetAllAsync(paginationParams.PageNumber, paginationParams.PageSize);
            Response.AddPaginationHeader(new PaginationHeader(paginationParams.PageNumber, paginationParams.PageSize, notes.TotalCount, notes.TotalPages));
            return Ok(notes);
        }
        [HttpGet("user/turma/{id}")]
        [Authorize(Roles = "Aluno, Administrador")]
        public async Task<ActionResult> GetAllNotesBySchoolClassUser([FromQuery] PaginationParams paginationParams, int id)
        {
            var userId = User.GetUserId();
            var notes = await _noteService.GetNotesBySchoolClassUser(paginationParams.PageNumber, paginationParams.PageSize, id, userId);
            Response.AddPaginationHeader(new PaginationHeader(paginationParams.PageNumber, paginationParams.PageSize, notes.TotalCount, notes.TotalPages));
            return Ok(notes);
        }
    }
}

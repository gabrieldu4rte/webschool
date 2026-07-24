using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebSchool.API.Extensions;
using WebSchool.API.Models;
using WebSchool.Application.DTOs.Tuition;
using WebSchool.Application.Interfaces;
using WebSchool.Domain.Entities;

namespace WebSchool.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Administrador")]
    public class TuitionController : Controller
    {
        private readonly ITuitionService _tuitionService;

        public TuitionController(ITuitionService tuitionService)
        {
            _tuitionService = tuitionService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateTuition(TuitionPostDTO tuitionPostDTO)
        {
            var tuition = await _tuitionService.AddAsync(tuitionPostDTO);
            return Ok(new { message = "Matrícula criada com sucesso." });
        }

        [HttpPut]
        public async Task<ActionResult> UpdateTuition(TuitionPutDTO tuitionPutDTO)
        {
            var tuition = await _tuitionService.UpdateAsync(tuitionPutDTO);
            return Ok(new { message = "Matrícula atualizada com sucesso." });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTuition(int id)
        {
            var tuition = await _tuitionService.DeleteAsync(id);
            return Ok(new { message = "Matrícula excluída com sucesso." });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetTuitionById(int id)
        {
            var tuition = await _tuitionService.GetByIdAsync(id);
            return Ok(tuition);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllTuitions([FromQuery] PaginationParams paginationParams)
        {
            var tuitions = await _tuitionService.GetAllAsync(paginationParams.PageNumber, paginationParams.PageSize);
            Response.AddPaginationHeader(new PaginationHeader(paginationParams.PageNumber, paginationParams.PageSize, tuitions.TotalCount, tuitions.TotalPages));
            return Ok(tuitions);

        }
    }
}

using WebSchool.Application.Interfaces;
using WebSchool.Application.DTOs.Tuition;
using Microsoft.AspNetCore.Mvc;

namespace WebSchool.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
            if (tuition == null)
            {
                return BadRequest("Não foi possível criar a matrícula.");
            }
            return Ok(new { message = "Matrícula criada com sucesso." });
        }

        [HttpPut]
        public async Task<ActionResult> UpdateTuition(TuitionPutDTO tuitionPutDTO)
        {
            var tuition = await _tuitionService.UpdateAsync(tuitionPutDTO);
            if (tuition == null)
            {
                return NotFound("Matrícula não encontrada.");
            }
            return Ok(new { message = "Matrícula atualizada com sucesso." });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTuition(int id)
        {
            var tuition = await _tuitionService.DeleteAsync(id);
            if (tuition == null)
            {
                return NotFound("Matrícula não encontrada.");
            }
            return Ok(new { message = "Matrícula excluída com sucesso." });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetTuitionById(int id)
        {
            var tuition = await _tuitionService.GetByIdAsync(id);
            if (tuition == null)
            {
                return NotFound("Matrícula não encontrada.");
            }
            return Ok(tuition);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllTuitions()
        {
            var tuitions = await _tuitionService.GetAllAsync();
            return Ok(tuitions);

        }
    }
}

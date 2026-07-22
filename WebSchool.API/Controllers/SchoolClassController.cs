using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebSchool.Application.DTOs.SchoolClass;
using WebSchool.Application.Interfaces;
using WebSchool.Infra.Ioc;

namespace WebSchool.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SchoolClassController : Controller
    {
        private readonly ISchoolClassService _schoolClassService;

        public SchoolClassController(ISchoolClassService schoolClassService)
        {
            _schoolClassService = schoolClassService;
        }
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult> CreateSchoolClass(SchoolClassPostDTO schoolClassPostDTO)
        {
            var createdSchoolClass = await _schoolClassService.AddAsync(schoolClassPostDTO);
            return Ok(new { message = "Turma criada com sucesso." });
        }

        [HttpPut]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult> UpdateSchoolClass(SchoolClassPutDTO schoolClassPutDTO)
        {
            var updatedSchoolClass = await _schoolClassService.UpdateAsync(schoolClassPutDTO);
            return Ok(new { message = "Turma atualizada com sucesso." });
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult> DeleteSchoolClass(int id)
        {
            var deletedSchoolClass = await _schoolClassService.DeleteAsync(id);
            return Ok(new { message = "Turma deletada com sucesso." });
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult> GetSchoolClassById(int id)
        {
            var schoolClass = await _schoolClassService.GetByIdAsync(id);
            return Ok(schoolClass);
        }

        [HttpGet]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult> GetAllSchoolClasses()
        {
            var schoolClasses = await _schoolClassService.GetAllAsync();
            return Ok(schoolClasses);
        }

        [HttpGet("user")]
        [Authorize(Roles = "Aluno, Administrador")]
        public async Task<ActionResult> GetAllSchoolClassesByUser()
        {
            var userId = User.GetUserId();
            var schoolClasses = await _schoolClassService.GetSchoolClassesByUser(userId);
            return Ok(schoolClasses);
        }
    }
}
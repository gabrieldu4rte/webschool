using WebSchool.Application.Interfaces;
using WebSchool.Application.DTOs.Course;
using Microsoft.AspNetCore.Mvc;

namespace WebSchool.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateCourse(CoursePostDTO coursePostDTO)
        {
            var course = await _courseService.AddAsync(coursePostDTO);
            if (course == null)
            {
                return BadRequest("Não foi possível criar o curso.");
            }
            return Ok(new { message = "Curso criado com sucesso." });
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCourse(CoursePutDTO coursePutDTO)
        {
            var course = await _courseService.UpdateAsync(coursePutDTO);
            if (course == null)
            {
                return NotFound("Curso não encontrado.");
            }
            return Ok(new { message = "Curso atualizado com sucesso." });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCourse(int id)
        {
            var course = await _courseService.DeleteAsync(id);
            if (course == null)
            {
                return NotFound("Curso não encontrado.");
            }
            return Ok(new { message = "Curso excluído com sucesso." });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetCourseById(int id)
        {
            var course = await _courseService.GetByIdAsync(id);
            if (course == null)
            {
                return NotFound("Curso não encontrado.");
            }
            return Ok(course);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllCourses()
        {
            var courses = await _courseService.GetAllAsync();
            return Ok(courses);
        }
    }
}

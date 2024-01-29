using Kreta.Backend.Datas.Entities;
using Kreta.Backend.Repos;
using Kreta.Shared.Dtos;
using Kreta.Shared.Extensions;
using Kreta.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Kreta.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepo _studentRepo;
        public StudentController(IStudentRepo studentRepo)
        {
            _studentRepo = studentRepo ?? throw new ArgumentException("Student repo nem létrezik");
        }

        [HttpGet]
        public async Task<IActionResult> SelectStudentAsync()
        {
            List<StudentDto> studentsDtos = new List<StudentDto>();
            if (_studentRepo is not null)
            {
                List<Student> students = await _studentRepo.SelectStudentAsync();
                studentsDtos = students.Select(student => student.ToDto()).ToList();
                return Ok(studentsDtos);
            }
            return BadRequest("A diákadatok lekérése sikertelen!");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            StudentDto? entityDto = new StudentDto();
            if (_studentRepo is not null)
            {
                Student? resultStudent = await _studentRepo.GetByIdAsync(id);
                if (resultStudent != null)
                {
                    entityDto = resultStudent.ToDto();
                    return Ok(entityDto);
                }
                else
                {
                    return BadRequest("A keresett diák nem található!");
                }
            }
            return BadRequest("Diák keresése nem működik!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStudentAsync(StudentDto student)
        {
            ControllerResponse response = new ControllerResponse();
            if (_studentRepo is not null)
            {
                response = await _studentRepo.UpdateAsync(student.DtoToStuden());
                if (response.HasError)
                {
                    return BadRequest(response);
                }
                else
                {
                    return Ok(response);
                }
            }
            response.ClearAndAddError("Az adatok frissítés nem lehetséges!");
            return BadRequest(response);
        }
    }
}

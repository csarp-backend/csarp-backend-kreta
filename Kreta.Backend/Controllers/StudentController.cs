using Kreta.Backend.Datas.Entities;
using Kreta.Backend.Repos;
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
            List<Student> students = new List<Student>();
            if (_studentRepo is not null)
            {
                students = await _studentRepo.SelectStudentAsync();
                return Ok(students);
            }
            //return BadRequest(students);
            return BadRequest("A diákadatok lekérése sikertelen!");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            Student? entity = new Student();
            if (_studentRepo is not null)
            {
                entity = await _studentRepo.GetByIdAsync(id);
                if (entity != null)
                {
                    return Ok(entity);
                }
                else
                {
                    return BadRequest("A keresett diák nem található!");
                }
            }
            return BadRequest("Diák keresése nem működik!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStudentAsync(Student student)
        {
            ControllerResponse response = new ControllerResponse();
            if (_studentRepo is not null)
            {
                response = await _studentRepo.UpdateAsync(student);
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

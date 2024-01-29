using Kreta.Backend.Datas.Entities;
using Kreta.Backend.Repos;
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
            _studentRepo = studentRepo;
        }

        [HttpGet]
        public async Task<IActionResult> SelectStudentAsync()
        {
            List<Student> students = new List<Student>();
            if (students is null)
            {
                students= await _studentRepo.SelectStudentAsync();
                return Ok(students);
            }
            //return BadRequest(students);
            return BadRequest("A diákadatok lekérése sikertelen");

        }
    }
}

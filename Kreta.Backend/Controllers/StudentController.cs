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
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NZWalks.API.Controllers
{
    //https://localhost:5001/api/students
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        // GET: api/students
        [HttpGet]
         public IActionResult GetAllStudents()
        {
            string[] studentsNames = new string[]
            {
                "John Doe",
                "Jane Smith",
                "Alice Johnson",
                "Bob Brown"
            };
            return Ok(studentsNames);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentWebApp.ServiceLayer;
using StudentWebApp.WebLayer.DTOs;

namespace StudentWebApp.WebLayer
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        private IStudentService studentService;

        public StudentsController(IStudentService studentService)
        {
            this.studentService = studentService;
        }


        [HttpPost]
        [Consumes("application/json")]

        public CreatedResult CreateStudent([FromBody] StudentDTO studentDTO)
        {
            studentService.CreateStudent(studentDTO);
            return Created();
        }

        [HttpGet]
        public List<StudentDetailsDTO> GetAllStudents()
        {
           List<StudentDetailsDTO> allStudents = studentService.GetAllStudents();
           return allStudents; 
        }

        [HttpPut]
        [Consumes("application/json")]

    public StudentDetailsDTO UpdateStudent([FromBody] StudentUpdatedDTO studentUpdateDTO)
        {
           return studentService.UpdateStudent(studentUpdateDTO);
        }

    }

   
}

using StudentWebApp.RepositoryLayer.Data;
using StudentWebApp.RepositoryLayer.Models;
using StudentWebApp.ServiceLayer.Mappers;
using StudentWebApp.WebLayer.DTOs;

namespace StudentWebApp.ServiceLayer
{
    /**
     *  
     */
    public class StudentService : IStudentService
    {
        private SchoolContext _context;
        private IStudentMapper _mapper;

        public StudentService(SchoolContext context, IStudentMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public void CreateStudent(StudentDTO studentDTO)
        {
            Student student = _mapper.Convert(studentDTO);
            _context.CreateStudent(student);
        }

        public List<StudentDetailsDTO> GetAllStudents()
        {
            List<Student> dbStudents = _context.GetAllStudents();
            List<StudentDetailsDTO> studentDetailsDTOs = _mapper.ConvertList(dbStudents);

            return studentDetailsDTOs;
        }

        public StudentDetailsDTO UpdateStudent(StudentUpdatedDTO studentUpdateDTO)
        {
            //Student foundStudent = _mapper.Convert(studentUpdateDTO);
            //Student updatedStudent = _context.UpdateStudent(foundStudent);
            //find
            //update values on found foundStudent obj
            //save back in db
            //convert stundet saved in db to dto
            //return dto

            Student? foundStudent = _context.Students.FirstOrDefault(s => s.ID == studentUpdateDTO.StudentId);
            if (foundStudent == null) {
                throw new Exception("Student not found"); 
            }

            foundStudent.LastName = studentUpdateDTO.LastName;
            //foundStudent.EnrollmentDate = new DateTime(studentUpdateDTO.EnrollmentDate);

            Student savedStudent = _context.UpdateStudent(foundStudent);

            StudentDetailsDTO studentDTO = _mapper.Convert(savedStudent); 

            return studentDTO;
        }
    }
}

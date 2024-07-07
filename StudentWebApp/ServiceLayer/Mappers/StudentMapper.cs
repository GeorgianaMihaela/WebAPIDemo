using StudentWebApp.RepositoryLayer.Models;
using StudentWebApp.WebLayer.DTOs;

namespace StudentWebApp.ServiceLayer.Mappers
{
    public class StudentMapper : IStudentMapper
    {
        public Student Convert(StudentDTO studentDTO)
        {
            Student s = new Student();
            s.FirstMidName = studentDTO.FirstName;
            s.LastName = studentDTO.LastName;
            s.EnrollmentDate = DateTime.Now;    

            return s;
        }

        public StudentDetailsDTO Convert(Student student)
        {
            StudentDetailsDTO studentDTO = new StudentDetailsDTO();
            studentDTO.FirstName = student.FirstMidName; 
            studentDTO.LastName = student.LastName;
            studentDTO.EnrollmentDate = student.EnrollmentDate.ToString();

            return studentDTO; 
        }


        public List<StudentDetailsDTO> ConvertList(List<Student> students)
        {
            List<StudentDetailsDTO> studentDTOs = new List<StudentDetailsDTO>();

            foreach (Student s in students)
            {
                studentDTOs.Add(Convert(s));
            }
            return studentDTOs; 
        }

    }
}

using StudentWebApp.RepositoryLayer.Models;
using StudentWebApp.WebLayer.DTOs;

namespace StudentWebApp.ServiceLayer.Mappers
{
    public interface IStudentMapper
    {

        Student Convert(StudentDTO studentDTO);
        List<StudentDetailsDTO> ConvertList(List<Student> students);

        StudentDetailsDTO Convert(Student student); 

    }
}

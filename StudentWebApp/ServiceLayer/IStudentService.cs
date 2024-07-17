using StudentWebApp.WebLayer.DTOs;

namespace StudentWebApp.ServiceLayer
{
    public interface IStudentService
    {

        void CreateStudent(StudentDTO studentDTO);
        List<StudentDetailsDTO> GetAllStudents();
        StudentDetailsDTO UpdateStudent(int studentid, string lastname);
    }
}

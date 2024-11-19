using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IStudentService
    {
        List<Student> GetAllStudents(bool? isActive);
        Student? GetStudentByID(int id);
        Student AddStudent(AddUpdateStudent obj);
        Student? UpdateStudent(int id, AddUpdateStudent obj);
        bool DeleteStudentID(int id);
    }
}

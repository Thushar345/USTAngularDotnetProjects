using WebApplication1.Models;


namespace WebApplication1.Services
{
    public class StudentService : IStudentService
    {
        private readonly List<Student> _studentList;
        public StudentService()
        {
            _studentList = new List<Student>()
            {
                new Student(){
                Id = 1,
                FirstName = "Test",
                LastName = "",
                isActive = true,
                }
            };
        }

        public List<Student> GetAllStudents(bool? isActive)
        {
            return isActive == null ? _studentList : _studentList.Where(stu => stu.isActive == isActive).ToList();
        }

        public Student? GetStudentByID(int id)
        {
            return _studentList.FirstOrDefault(hero => hero.Id == id);
        }

        public Student AddStudent(AddUpdateStudent obj)
        {
            var addStudent = new Student()
            {
                Id = _studentList.Max(hero => hero.Id) + 1,
                FirstName = obj.FirstName,
                LastName = obj.LastName,
                isActive = obj.isActive,
            };

            _studentList.Add(addStudent);

            return addStudent;
        }

        public Student? UpdateStudent(int id, AddUpdateStudent obj)
        {
            var StudentIndex = _studentList.FindIndex(index => index.Id == id);
            if (StudentIndex > 0)
            {
                var hero = _studentList[StudentIndex];

                hero.FirstName = obj.FirstName;
                hero.LastName = obj.LastName;
                hero.isActive = obj.isActive;

                _studentList[StudentIndex] = hero;

                return hero;
            }
            else
            {
                return null;
            }
        }
        public bool DeleteStudentID(int id)
        {
            var StudentIndex = _studentList.FindIndex(index => index.Id == id);
            if (StudentIndex >= 0)
            {
                _studentList.RemoveAt(StudentIndex);
            }
            return StudentIndex >= 0;
        }
    }
}

using MYSchool.Models;

namespace MYSchool.Services.Interface
{
    public interface IStudentOperation
    {

        public bool CreateNewStudentList(Students students);

        public List<Students> ALLStudents();

        public Students GetStudentById(int id);
        public Students EditStudent(int id, Students stu);

        public bool DeleteStudent(int id);
    }
}

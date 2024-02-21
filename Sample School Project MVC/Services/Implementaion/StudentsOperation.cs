using Microsoft.EntityFrameworkCore;
using MYSchool.Database;
using MYSchool.Models;
using MYSchool.Services.Interface;

namespace MYSchool.Services.Implementaion
{
    public class StudentsOperation : IStudentOperation
    {
        private readonly StudentContext _studentContext;

        public StudentsOperation(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }
        //list of the student
        public List<Students> ALLStudents()
        {
            var students = _studentContext.NewStudents.ToList();
           if(students.Count > 0)
            {
                return students;
            }
            else
            {
                return null;
            }
        }
        //added new student
        public bool CreateNewStudentList(Students students)
        {

            try
            {
                _studentContext.Add(students);
                _studentContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

               return false;
            }

        }

        public Students GetStudentById(int id)
        {
           var student =  _studentContext.NewStudents.Where(x=>x.Id == id).FirstOrDefault();

            return student;
        }

        public Students EditStudent(int id , Students stu)
        {
            var isstudent = _studentContext.NewStudents.Where(x => x.Id == id);

            if (isstudent.Any())
            {
                var student = isstudent.FirstOrDefault();

                student.Fname = stu.Fname;
                student.Email = stu.Email;
                student.Lname= stu.Lname;
                student.Address = stu.Address;
                student.Phone = stu.Phone;
                student.RollNumber = stu.RollNumber;
                student.Class = stu.Class;

                _studentContext.SaveChanges();
                return student;
            }
            else
            {
                return null;
            }

        }

        public bool DeleteStudent(int id)
        {
            var isstudent = _studentContext.NewStudents.Where(x => x.Id == id);

            if (isstudent.Any())
            {
                Students? student = isstudent.FirstOrDefault();
                _studentContext.NewStudents.Remove(student);
                _studentContext.SaveChanges();
                return true;

            }

            return false;
        }
    }
}

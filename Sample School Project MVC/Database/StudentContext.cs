using Microsoft.EntityFrameworkCore;
using MYSchool.Models;

namespace MYSchool.Database
{
    public class StudentContext : DbContext
    {

        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {
            
        }

        //creating tables here ORM Classes

        public DbSet<Students> NewStudents { get; set; }
    }
}

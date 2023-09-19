using Microsoft.EntityFrameworkCore;

namespace WebAPI_Supersoft.Models
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {

        }
        public DbSet<StudentsLogin> StudentsLogin { get; set;}
    }
    public class StudentsLogin
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;

namespace BackendProj.Models;

public class SchoolContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Grade> Grades { get; set; }

    public SchoolContext(DbContextOptions options) : base(options)
    {
    }
}
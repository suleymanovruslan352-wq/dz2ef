using Microsoft.EntityFrameworkCore;




namespace dz2ef.context
{
    public class AppDbContext : DbContext
    {

       public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Teacher> Teachers { get; set; } = null!;
        public DbSet<Course> Courses { get; set; } = null!;
        public DbSet<StudentCard> StudentCards { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=EFcore1;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}

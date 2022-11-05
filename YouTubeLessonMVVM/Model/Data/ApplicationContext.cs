using Microsoft.EntityFrameworkCore;


namespace YouTubeLessonMVVM.Model.Data
{
    public class ApplicationContext: DbContext
    {
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Department> Departments { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder OptionsBuilder)
        {
            OptionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=YouTubeLessonsMVVMDB;Trusted_Connection=True;");
        }

    }
}

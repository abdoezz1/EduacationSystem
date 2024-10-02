using Microsoft.EntityFrameworkCore;

namespace MVC_day1.Models
{
    public class Intelligent : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = DESKTOP-02HVF36\\SQLEXPRESS ; Database = Intelligent; Trusted_Connection=true;encrypt=false ");
            base.OnConfiguring(optionsBuilder);
            
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Crs_result> Crs_Results { get; set; }
        public async Task<bool> IsObjectUniqueAsync(Instructor obj)
        {
            return !await Instructors
                .AnyAsync(o => o.Name == obj.Name && o.Address == obj.Address && o.Salary == obj.Salary && o.Dept_id == obj.Dept_id && o.Course_id == obj.Course_id);
        }
        public async Task<bool> IsObjectUniqueAsync(Trainee obj)
        {
            return !await Trainees
                .AnyAsync(o => o.Name == obj.Name && o.Address == obj.Address && o.Dept_id == obj.Dept_id);
        }

    }
}

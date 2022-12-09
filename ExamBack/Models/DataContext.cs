using Microsoft.EntityFrameworkCore;

namespace ExamBack.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { 
            Database.EnsureCreated();
        }

        public DbSet<Patient> Patients { get; set; } = null!;
        public DbSet<Appointment> Appointments { get; set; } = null!;

    }
}

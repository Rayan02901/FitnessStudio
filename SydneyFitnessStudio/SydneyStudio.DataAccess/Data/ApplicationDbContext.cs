using  Microsoft.EntityFrameworkCore;
using SydneyStudio.Models.Models;
namespace SydneyStudio.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Class> Classes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>().HasData(
                new Class {ClassId = 1, Name = "Pilates", Description="Do Pilates to stay healthy for a long time." },
                 new Class { ClassId = 2, Name = "Yoga", Description = "Do yoga to be in sync with nature." },
                  new Class { ClassId = 3, Name = "HIW", Description = "Do High Intensity Workout to gain Muscles." }
                );
        }
    }
    
}

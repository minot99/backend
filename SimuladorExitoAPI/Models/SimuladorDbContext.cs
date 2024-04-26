using Microsoft.EntityFrameworkCore;
using SimuladorExitoAPI.Models.ModelConfigurations;

namespace SimuladorExitoAPI.Models
{
    public class SimuladorDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("User ID=admin;Password=O0X2O5l8TeDk1rZdRblP;Initial Catalog=simulador_db;Server=simulador-bd.ckiahkstouyr.us-east-1.rds.amazonaws.com;TrustServerCertificate=true;");
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FacultyConfiguration());
            modelBuilder.ApplyConfiguration(new CareerConfiguration());
            modelBuilder.ApplyConfiguration(new PostgraduateConfiguration());
            modelBuilder.ApplyConfiguration(new PositionConfiguration());
            modelBuilder.ApplyConfiguration(new MilestoneConfiguration());
            modelBuilder.ApplyConfiguration(new MilestonePositionConfiguration());
            modelBuilder.ApplyConfiguration(new MilestonePostgraduateConfiguration());
        }

        public DbSet<Faculty> Faculties { get; set;}
        public DbSet<Career> Careers { get; set; }
        public DbSet<Postgraduate> Postgraduates { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Milestone> Milestones { get; set; }
        public DbSet<MilestonePosition> MilestonePositions { get; set; }
        public DbSet<MilestonePostgraduate> MilestonePostgraduates { get; set; }

    }
}

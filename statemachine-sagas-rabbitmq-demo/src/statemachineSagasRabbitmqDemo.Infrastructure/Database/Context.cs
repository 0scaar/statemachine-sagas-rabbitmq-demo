using Microsoft.EntityFrameworkCore;
using Entity = statemachineSagasRabbitmqDemo.Infrastructure.Database.Entities;
using statemachineSagasRabbitmqDemo.Infrastructure.Database.Map;

namespace statemachineSagasRabbitmqDemo.Infrastructure.Database
{
    public class Context : DbContext
    {
        public DbSet<Entity::File> Files { get; set; }
        public DbSet<Entity::FileDetail> FileDetails { get; set; }
        public DbSet<Entity::FileLog> FileLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("DEMO_CONN")))
            {
                optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("DEMO_CONN"), npgsqlOptionsAction: options =>
                {
                    options.EnableRetryOnFailure(2, TimeSpan.FromSeconds(5), new List<string>());
                    options.MigrationsHistoryTable("_MigrationHistory", "SagaDemo");
                });
            }
            else
            {
                optionsBuilder.UseInMemoryDatabase("DemoInMemory");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FileConfiguration());
            modelBuilder.ApplyConfiguration(new FileDetailConfiguration());
            modelBuilder.ApplyConfiguration(new FileLogConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}

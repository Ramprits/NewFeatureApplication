using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using New_Application.Models;

namespace New_Application.Infrastructure {
    public class NewApplicationDbContext : DbContext {
        public NewApplicationDbContext (DbContextOptions<NewApplicationDbContext> options) : base (options) { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        protected override void OnModelCreating (ModelBuilder modelBuilder) {

            foreach (var entityType in modelBuilder.Model.GetEntityTypes ()) {
                modelBuilder.Entity (entityType.Name).Property<DateTime> ("LastModified");
                modelBuilder.Entity (entityType.Name).Ignore ("IsDirty");
            }
        }
        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) {
            //optionsBuilder.UseSqlServer(
            //  "Server = (localdb)\\mssqllocaldb; Database = SamuraiDataCoreWeb; Trusted_Connection = True; ",
            //  options => options.MaxBatchSize(30));
            //optionsBuilder.EnableSensitiveDataLogging();
        }
        public override int SaveChanges () {
            foreach (var entry in ChangeTracker.Entries ()
                    .Where (e => e.State == EntityState.Added ||
                        e.State == EntityState.Modified)) {
                entry.Property ("LastModified").CurrentValue = DateTime.Now;
            }
            return base.SaveChanges ();
        }
    }
}
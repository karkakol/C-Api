using Microsoft.EntityFrameworkCore;
using AnimalReviewApp.Model;

namespace AnimalReviewApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Animal> Animal { get; set; }
        public DbSet<AnimalOwner> AnimalOwners { get; set; }
        public DbSet<AnimalCategory> AnimalCategories { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnimalCategory>()
                    .HasKey(pc => new { pc.AnimalId, pc.CategoryId });
            modelBuilder.Entity<AnimalCategory>()
                    .HasOne(p => p.Animal)
                    .WithMany(pc => pc.AnimalCategories)
                    .HasForeignKey(p => p.AnimalId);
            modelBuilder.Entity<AnimalCategory>()
                    .HasOne(p => p.Category)
                    .WithMany(pc => pc.AnimalCategories)
                    .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<AnimalOwner>()
                    .HasKey(po => new { po.AnimalId, po.OwnerId });
            modelBuilder.Entity<AnimalOwner>()
                    .HasOne(p => p.Animal)
                    .WithMany(pc => pc.AnimalOwners)
                    .HasForeignKey(p => p.AnimalId);
            modelBuilder.Entity<AnimalOwner>()
                    .HasOne(p => p.Owner)
                    .WithMany(pc => pc.AnimalOwners)
                    .HasForeignKey(c => c.OwnerId);
        }
    }
}

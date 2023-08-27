using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SuperStoreAPI.SQL.Context.Interfaces;
using SuperStoreAPI.SQL.Models;

namespace SuperStoreAPI.SQL.Context
{
    public class SuperStoreContextFactory : IDesignTimeDbContextFactory<SuperStoreContext>
    {
        public SuperStoreContext CreateDbContext(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("local.settings.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<SuperStoreContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("SUPER_STORE_CONNECTION"));

            return new SuperStoreContext(optionsBuilder.Options);
         }
    }

    public partial class SuperStoreContext : DbContext, ISuperStoreContext
    {
        public SuperStoreContext() { }
        public SuperStoreContext(DbContextOptions<SuperStoreContext> options) : base(options) { }

        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Products", "dbo");
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Title).HasMaxLength(250);
                entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.Image).HasMaxLength(500);
                entity.Property(e => e.Rate).HasColumnType("decimal(1,1)");
                entity.Property(e => e.Count).HasColumnType("int");
                entity.Property(e => e.Category).HasMaxLength(500);
                entity.Property(e => e.Quantity).HasColumnType("int");
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

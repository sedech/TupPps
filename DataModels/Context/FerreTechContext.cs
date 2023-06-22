

using DataModels.Configuration;
using DataModels.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataModels.Context
{


    public partial class FerreTechContext : DbContext
    {
        public FerreTechContext():base()
        {
        }

        public FerreTechContext(DbContextOptions<FerreTechContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<HistoryPrice> HistoryPrices { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Product> Products { get; set; }

        public virtual DbSet<Brand> Brands { get; set; }

        public virtual DbSet<Role> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=SEDECH\\SQLEXPRESS;Database=FerreTechs;TrustServerCertificate=True;User=sa;Password=cayetano");
            }
        }
           


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ModelConfig(modelBuilder);
        }

        private void ModelConfig(ModelBuilder modelBuilder)
        {
            new AccountConfiguration(modelBuilder.Entity<Account>());
            new BrandConfiguration(modelBuilder.Entity<Brand>());
            new CategoryConfiguration(modelBuilder.Entity<Category>());
            new HistoryPriceConfiguration(modelBuilder.Entity<HistoryPrice>());
            new OrderConfiguration(modelBuilder.Entity<Order>());
            new OrderItemConfiguration(modelBuilder.Entity<OrderItem>());
            new ProductConfiguration(modelBuilder.Entity<Product>());
            new RoleConfiguration(modelBuilder.Entity<Role>());
        }


    }
}



using DataModels.Configuration;
using DataModels.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataModels.Context
{


    public partial class FerreTechContext : IdentityDbContext<IdentityUser>
    {
        public FerreTechContext():base()
        {
        }

        public FerreTechContext(DbContextOptions<FerreTechContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }

        public virtual DbSet<IdentityUser> Users { get; set; }
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

            //setear roles de usuario
            
            //

            string ADMIN_ROLE = "341743f0-asd2–42de-afbf-59kmkkmk72cf6";
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN",
                Id = ADMIN_ROLE,
                ConcurrencyStamp = ADMIN_ROLE
            });


            //seed cliente role
            string CLIENTE_ROLE = "601f0ede-374e-45f0-9373-50cba7a8183e";
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "Cliente",
                NormalizedName = "CLIENTE",
                Id = CLIENTE_ROLE,
                ConcurrencyStamp = CLIENTE_ROLE
            });

            //seed vendedor role
            string VENDEDOR_ROLE = "65450c8a-1e5b-11ee-be56-0242ac120002";
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "Vendedor",
                NormalizedName = "VENDEDOR",
                Id = VENDEDOR_ROLE,
                ConcurrencyStamp = VENDEDOR_ROLE
            });

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

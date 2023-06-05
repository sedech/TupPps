using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TupPps.Entities;

namespace TupPps.Data;

public partial class FerreTechContext : DbContext
{
    public FerreTechContext()
    {
    }

    public FerreTechContext(DbContextOptions<FerreTechContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<HistorialPrecio> HisorialPrecios { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<PedidoItem> PedidoItems { get; set; }

    public  DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Vendedor> Vendedors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=SEDECH\\SQLEXPRESS;Database=FerreTech;TrustServerCertificate=True;User=sa;Password=cayetano");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        ModelConfig(modelBuilder);
    }

    private void ModelConfig(ModelBuilder modelBuilder)
    {

    }
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AdvertisingAgency;

public partial class DAContext : DbContext
{
    public DAContext()
    {
    }

    public DAContext(DbContextOptions<DAContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrdersList> OrdersLists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\AdvertisingAgency\\BDAA.mdf;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.IdClient);

            entity.Property(e => e.Adress).HasColumnType("text");
            entity.Property(e => e.Clien).HasColumnType("text");
            entity.Property(e => e.ClientName).HasColumnType("text");
            entity.Property(e => e.ClientSurname).HasColumnType("text");
            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
            entity.Property(e => e.Passport).HasColumnType("text");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderNumber);

            entity.Property(e => e.DateOfOrder).HasColumnType("date");

            entity.HasOne(d => d.ClientCodeNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ClientCode)
                .HasConstraintName("FK_Orders_ToClients");

            entity.HasOne(d => d.OrderCodeNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.OrderCode)
                .HasConstraintName("FK_Orders_ToOrdersList");
        });

        modelBuilder.Entity<OrdersList>(entity =>
        {
            entity.HasKey(e => e.IdOrder);

            entity.ToTable("OrdersList");

            entity.Property(e => e.OrderName).HasColumnType("text");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

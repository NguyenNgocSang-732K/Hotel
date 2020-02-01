using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WEBCORE_API.Models.Entities
{
    public partial class AceEntitie : DbContext
    {
        public AceEntitie()
        {
        }

        public AceEntitie(DbContextOptions<AceEntitie> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Booking> Booking { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<Services> Services { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=Hotel;user id=sa;password=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.DateEnd).HasColumnType("date");

                entity.Property(e => e.DateStart).HasColumnType("date");

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.BookingIdCustomerNavigation)
                    .HasForeignKey(d => d.IdCustomer)
                    .HasConstraintName("FK_Booking_Account2");

                entity.HasOne(d => d.IdEmpNavigation)
                    .WithMany(p => p.BookingIdEmpNavigation)
                    .HasForeignKey(d => d.IdEmp)
                    .HasConstraintName("FK_Booking_Account3");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("FK_Booking_Room");
            });

            modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.HasKey(e => new { e.ServicesId, e.OrderId });

                entity.Property(e => e.ServicesId).HasColumnName("ServicesID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetails_Orders");

                entity.HasOne(d => d.Services)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ServicesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetails_Services");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.DateEnd).HasColumnType("datetime");

                entity.Property(e => e.DtaeStart).HasColumnType("datetime");

                entity.Property(e => e.Total).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Orders)
                    .HasForeignKey<Orders>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Account");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdEmpNavigation)
                    .WithMany(p => p.Room)
                    .HasForeignKey(d => d.IdEmp)
                    .HasConstraintName("FK_Room_Account");
            });

            modelBuilder.Entity<Services>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

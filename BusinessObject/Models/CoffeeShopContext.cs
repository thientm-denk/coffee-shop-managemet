using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BusinessObject.Models
{
    public partial class CoffeeShopContext : DbContext
    {
        public CoffeeShopContext()
        {
        }

        public CoffeeShopContext(DbContextOptions<CoffeeShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Drink> Drinks { get; set; } = null!;
        public virtual DbSet<DrinkType> DrinkTypes { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<Shift> Shifts { get; set; } = null!;
        public virtual DbSet<ShiftDetail> ShiftDetails { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Voucher> Vouchers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server =(local); database = CoffeeShop;uid=sa;pwd=12345;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drink>(entity =>
            {
                entity.Property(e => e.DrinkId).HasColumnName("drinkId");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.TypeId).HasColumnName("typeId");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Drinks)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Drinks__typeId__267ABA7A");
            });

            modelBuilder.Entity<DrinkType>(entity =>
            {
                entity.HasKey(e => e.TypeId)
                    .HasName("PK__DrinkTyp__F04DF13A8059F897");

                entity.Property(e => e.TypeId).HasColumnName("typeId");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("orderId");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ShiftId).HasColumnName("shiftId");

                entity.Property(e => e.Date)
                        .HasColumnType("date")
                        .HasColumnName("date");


                entity.Property(e => e.Time).HasColumnName("time");

                entity.HasOne(d => d.Shift)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ShiftId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__shiftId__30F848ED");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => e.OrderDetailsId)
                    .HasName("PK__OrderDet__5EEE52738F78F3A0");

                entity.Property(e => e.OrderDetailsId).HasColumnName("orderDetailsId");

                entity.Property(e => e.DrinkId).HasColumnName("drinkId");

                entity.Property(e => e.OrderId).HasColumnName("orderId");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.VocherId).HasColumnName("vocherId");

                entity.HasOne(d => d.Drink)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.DrinkId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderDeta__drink__36B12243");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderDeta__order__35BCFE0A");

                entity.HasOne(d => d.Vocher)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.VocherId)
                    .HasConstraintName("FK__OrderDeta__voche__37A5467C");
            });

            modelBuilder.Entity<Shift>(entity =>
            {
                entity.Property(e => e.ShiftId).HasColumnName("shiftId");

                entity.Property(e => e.ShiftName)
                    .HasMaxLength(30)
                    .HasColumnName("shiftName");
            });

            modelBuilder.Entity<ShiftDetail>(entity =>
            {
                entity.HasKey(e => e.ShiftDetailsId)
                    .HasName("PK__ShiftDet__6C92379E4B23648D");

                entity.Property(e => e.ShiftDetailsId).HasColumnName("shiftDetailsId");

                entity.Property(e => e.CloseWallet).HasColumnName("closeWallet");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.OpenWallet).HasColumnName("openWallet");

                entity.Property(e => e.ShiftId).HasColumnName("shiftId");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Shift)
                    .WithMany(p => p.ShiftDetails)
                    .HasForeignKey(d => d.ShiftId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ShiftDeta__shift__2E1BDC42");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ShiftDetails)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ShiftDeta__userI__2D27B809");
            });


            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .HasColumnName("password");

                entity.Property(e => e.Role)
                    .HasMaxLength(10)
                    .HasColumnName("role");
            });

            modelBuilder.Entity<Voucher>(entity =>
            {
                entity.Property(e => e.VoucherId).HasColumnName("voucherId");

                entity.Property(e => e.Status).HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

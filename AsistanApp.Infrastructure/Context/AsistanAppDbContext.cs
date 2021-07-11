using System;
using AsistanApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AsistanApp.Infrastructure.Context
{
    public partial class AsistanAppDbContext : DbContext
    {
        public AsistanAppDbContext()
        {
        }

        public AsistanAppDbContext(DbContextOptions<AsistanAppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Apartment> Apartments { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<Blok> Bloks { get; set; }
        public virtual DbSet<BlokFloor> BlokFloors { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Indent> Indents { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<NumberOfRoom> NumberOfRooms { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<PaymentCategory> PaymentCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server= DESKTOP-KUV1GT2;Database=AsistanAppDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");

            modelBuilder.Entity<Apartment>(entity =>
            {
                entity.ToTable("Apartment");

                entity.Property(e => e.FullOrEmpty).HasDefaultValueSql("((0))");

                entity.Property(e => e.HostOrTenant).HasDefaultValueSql("((0))");

                entity.Property(e => e.UserId).HasMaxLength(450);

                entity.HasOne(d => d.Floor)
                    .WithMany(p => p.Apartments)
                    .HasForeignKey(d => d.FloorId)
                    .HasConstraintName("FK_Apartment_FloorId");

                entity.HasOne(d => d.NumberOfRoom)
                    .WithMany(p => p.Apartments)
                    .HasForeignKey(d => d.NumberOfRoomId)
                    .HasConstraintName("FK_Apartment_NumberOfRoom");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Apartments)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Apartment_AspNetUsers");
            });

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.IdentityNumber).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId, "IX_AspNetUserRoles_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Blok>(entity =>
            {
                entity.ToTable("Blok");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<BlokFloor>(entity =>
            {
                entity.ToTable("BlokFloor");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Blok)
                    .WithMany(p => p.BlokFloors)
                    .HasForeignKey(d => d.BlokId)
                    .HasConstraintName("FK_BlokFloor_Id");
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.ToTable("Car");

                entity.Property(e => e.Description).HasMaxLength(40);

                entity.Property(e => e.LicensePlate).HasMaxLength(15);

                entity.Property(e => e.UserId).HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Car_UserId");
            });

            modelBuilder.Entity<Indent>(entity =>
            {
                entity.ToTable("Indent");

                entity.Property(e => e.CreatedAt).HasColumnType("smalldatetime");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.Indents)
                    .HasForeignKey(d => d.PaymentId)
                    .HasConstraintName("FK_Indent_ApartmentId");

                entity.HasOne(d => d.PaymentNavigation)
                    .WithMany(p => p.Indents)
                    .HasForeignKey(d => d.PaymentId)
                    .HasConstraintName("FK_Indent_PaymentId");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("Message");

                entity.Property(e => e.CreatedAt).HasColumnType("smalldatetime");

                entity.Property(e => e.RecipientId).HasMaxLength(450);

                entity.Property(e => e.WriterUserId).HasMaxLength(450);

                entity.HasOne(d => d.Recipient)
                    .WithMany(p => p.MessageRecipients)
                    .HasForeignKey(d => d.RecipientId)
                    .HasConstraintName("FK_Car_RecipientId");

                entity.HasOne(d => d.WriterUser)
                    .WithMany(p => p.MessageWriterUsers)
                    .HasForeignKey(d => d.WriterUserId)
                    .HasConstraintName("FK_Car_WriterUserId");
            });

            modelBuilder.Entity<NumberOfRoom>(entity =>
            {
                entity.ToTable("NumberOfRoom");

                entity.Property(e => e.Description).HasMaxLength(50);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.Property(e => e.CreatedPaymentDate).HasColumnType("datetime");

                entity.Property(e => e.FinalDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.PaymentCategory)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.PaymentCategoryId)
                    .HasConstraintName("FK_Payment_Id");
            });

            modelBuilder.Entity<PaymentCategory>(entity =>
            {
                entity.ToTable("PaymentCategory");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

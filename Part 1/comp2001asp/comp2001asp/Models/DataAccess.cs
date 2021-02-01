using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace comp2001asp.Models
{
    public partial class DataAccess : DbContext
    {
        public DataAccess()
        {
        }

        public DataAccess(DbContextOptions<DataAccess> options)
            : base(options)
        {
        }

        public virtual DbSet<Password> Passwords { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=socem1.uopnet.plymouth.ac.uk;Database=COMP2001_MRileyWallace;User Id=MRileyWallace;Password=FwuH652*");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Password>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.OldPassword)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("Old_Password");

                entity.Property(e => e.PChanged)
                    .HasColumnType("datetime")
                    .HasColumnName("P_Changed");

                entity.Property(e => e.UsersId).HasColumnName("Users_ID");

                entity.HasOne(d => d.Users)
                    .WithMany()
                    .HasForeignKey(d => d.UsersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Passwords__Users__68336F3E");
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.LoginDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Login_Date");

                entity.Property(e => e.SessionsId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Sessions_ID");

                entity.Property(e => e.UsersId).HasColumnName("Users_ID");

                entity.HasOne(d => d.Users)
                    .WithMany()
                    .HasForeignKey(d => d.UsersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Sessions__Users___6A1BB7B0");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UsersId)
                    .HasName("PK__Users__EB68290D43D863E9");

                entity.Property(e => e.UsersId).HasColumnName("Users_ID");

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("User_Email");

                entity.Property(e => e.UserForeName)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("User_ForeName");

                entity.Property(e => e.UserLastName)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("User_LastName");

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("User_Password");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

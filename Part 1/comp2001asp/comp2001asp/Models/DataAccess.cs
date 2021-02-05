using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace comp2001asp.Models
{
    public partial class DataAccess : DbContext
    {
        public bool Validate(User user)
        {
            SqlParameter parameter = new SqlParameter("ReturnValue", SqlDbType.Int, 128);
            parameter.Direction = ParameterDirection.Output;

            Database.ExecuteSqlRaw("EXEC @ReturnValue = Validate_User @User_Email, @User_Password",
                parameter,
                new SqlParameter("@User_Email", user.User_Email),
                new SqlParameter("@User_Password", user.User_Password));

            if (Convert.ToInt32(parameter.Value) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Register(User user, out string output)
        {
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@ResponseMessage";
            parameter.IsNullable = true;
            parameter.SqlDbType = System.Data.SqlDbType.VarChar;
            parameter.Direction = System.Data.ParameterDirection.Output;
            parameter.Size = 50;


            Database.ExecuteSqlRaw("EXEC Register_User @User_ForeName, @User_LastName, @User_Email, @User_Password",
                new SqlParameter("@User_ForeName", user.User_ForeName),
                new SqlParameter("@User_LastName", user.User_LastName),
                new SqlParameter("@User_Email", user.User_Email),
                new SqlParameter("@User_Password", user.User_Password.ToString()), parameter
                );

            output = parameter.Value.ToString();

        }

        public void Update(User user, int User)
        {
            Database.ExecuteSqlRaw("EXEC Update_User @Users_ID, @User_ForeName, @User_LastName, @User_Email, @User_Password",
                new SqlParameter("@Users_ID", User),
                new SqlParameter("@User_ForeName", user.User_ForeName),
                new SqlParameter("@User_LastName", user.User_LastName),
                new SqlParameter("@User_Email", user.User_Email),
                new SqlParameter("@User_Password", user.User_Password)

                );
        }


        public void Delete (int User)
        {
            Database.ExecuteSqlRaw("EXEC Delete_User @Users_ID",
                new SqlParameter("@Users_ID", User));
        }
















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

       /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=socem1.uopnet.plymouth.ac.uk;Database=COMP2001_MRileyWallace;User Id=MRileyWallace;Password=FwuH652*");
            }
        }*/

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
                entity.HasKey(e => e.Users_ID)
                    .HasName("PK__Users__EB68290D43D863E9");

                entity.Property(e => e.Users_ID).HasColumnName("Users_ID");

                entity.Property(e => e.User_Email)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("User_Email");

                entity.Property(e => e.User_ForeName)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("User_ForeName");

                entity.Property(e => e.User_LastName)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("User_LastName");

                entity.Property(e => e.User_Password)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("User_Password");
            });

            OnModelCreatingPartial(modelBuilder);
        }






        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }


}

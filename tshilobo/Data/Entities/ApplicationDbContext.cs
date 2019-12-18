using Microsoft.EntityFrameworkCore;

namespace tshilobo.Data.Entities
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Church> Church { get; set; }
        public virtual DbSet<ChurchAddress> ChurchAddress { get; set; }
        public virtual DbSet<ChurchBanner> ChurchBanner { get; set; }
        public virtual DbSet<Denomination> Denomination { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RoleClaim> RoleClaim { get; set; }
        public virtual DbSet<Theme> Theme { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserClaim> UserClaim { get; set; }
        public virtual DbSet<UserLogin> UserLogin { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<UserTitle> UserTitle { get; set; }
        public virtual DbSet<UserToken> UserToken { get; set; }       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Church>(entity =>
            {
                entity.Property(e => e.ChurchCode)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ChurchLeaderId).HasMaxLength(450);

                entity.Property(e => e.ChurchName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.CreatorId).HasMaxLength(450);

                entity.Property(e => e.FounderName).HasMaxLength(50);

                entity.Property(e => e.FoundingDate).HasColumnType("date");

                entity.Property(e => e.MainBelief).HasMaxLength(500);

                entity.Property(e => e.MissionStatement).HasMaxLength(450);

                entity.Property(e => e.VisionStatement).HasMaxLength(450);

                entity.HasOne(d => d.ChurchLeader)
                    .WithMany(p => p.ChurchChurchLeader)
                    .HasForeignKey(d => d.ChurchLeaderId)
                    .HasConstraintName("FK_Church_User(LeaderID)");

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.ChurchCreator)
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_Church_User");

                entity.HasOne(d => d.Denomination)
                    .WithMany(p => p.Church)
                    .HasForeignKey(d => d.DenominationId)
                    .HasConstraintName("FK_Church_Denomination");
            });

            modelBuilder.Entity<ChurchAddress>(entity =>
            {
                entity.HasKey(e => e.AddressId);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Province)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.StreetAddress)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ZipCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Church)
                    .WithMany(p => p.ChurchAddress)
                    .HasForeignKey(d => d.ChurchId)
                    .HasConstraintName("FK_ChurchAddress_Church");
            });

            modelBuilder.Entity<ChurchBanner>(entity =>
            {
                entity.HasKey(e => e.BannerId);

                entity.Property(e => e.BannerId).ValueGeneratedNever();

                entity.Property(e => e.BannerContent)
                    .IsRequired()
                    .HasColumnType("image");

                entity.Property(e => e.BannnerName)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Church)
                    .WithMany(p => p.ChurchBanner)
                    .HasForeignKey(d => d.ChurchId)
                    .HasConstraintName("FK_ChurchBanner_Church");
            });

            modelBuilder.Entity<Denomination>(entity =>
            {
                entity.Property(e => e.DenominationId).ValueGeneratedNever();

                entity.Property(e => e.Denomination1)
                    .IsRequired()
                    .HasColumnName("Denomination")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.DepartmentId).ValueGeneratedNever();

                entity.Property(e => e.DepartmentName).HasMaxLength(50);
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.Property(e => e.Gname)
                    .IsRequired()
                    .HasColumnName("GName")
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<RoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleClaim)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<Theme>(entity =>
            {
                entity.Property(e => e.CreatorId).HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.YearTheme)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.Church)
                    .WithMany(p => p.Theme)
                    .HasForeignKey(d => d.ChurchId)
                    .HasConstraintName("FK_ChurchTheme_Church");

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.Theme)
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_ChurchTheme_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.BelongsToAchurch).HasColumnName("BelongsToAChurch");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Discriminator)
                    .IsRequired()
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.GenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Gender");
            });

            modelBuilder.Entity<UserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserClaim)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<UserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserLogin)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<UserTitle>(entity =>
            {
                entity.HasKey(e => e.TitleId);

                entity.Property(e => e.TitleId).ValueGeneratedNever();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<UserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserToken)
                    .HasForeignKey(d => d.UserId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

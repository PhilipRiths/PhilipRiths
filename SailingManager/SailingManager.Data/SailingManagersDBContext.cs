using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SailingManager.Data
{
    public partial class SailingManagersDBContext : DbContext
    {
        public virtual DbSet<Addresses> Addresses { get; set; }
        public virtual DbSet<ApplicationRoles> ApplicationRoles { get; set; }
        public virtual DbSet<Attendants> Attendants { get; set; }
        public virtual DbSet<Boats> Boats { get; set; }
        public virtual DbSet<Clubs> Clubs { get; set; }
        public virtual DbSet<CrewMembers> CrewMembers { get; set; }
        public virtual DbSet<Entries> Entries { get; set; }
        public virtual DbSet<Events> Events { get; set; }
        public virtual DbSet<Races> Races { get; set; }
        public virtual DbSet<Regattas> Regattas { get; set; }
        public virtual DbSet<RegisteredEntryUsers> RegisteredEntryUsers { get; set; }
        public virtual DbSet<Results> Results { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Socials> Socials { get; set; }
        public virtual DbSet<Teams> Teams { get; set; }
        public virtual DbSet<UserApplicationRoles> UserApplicationRoles { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        // Unable to generate entity type for table 'dbo.UserRegattaRoles'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.UserEventRoles'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.UserClubRoles'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.RaceTeams'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server = DESKTOP-LDC25OT; Database = SailingManagersDB; Trusted_Connection = true; ");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Addresses>(entity =>
            {
                entity.HasIndex(e => new { e.AddressRow, e.ZipCode, e.Country })
                    .HasName("uc_Adresses_AdressRow_ZipCode_Country")
                    .IsUnique();

                entity.Property(e => e.Active).HasDefaultValueSql("1");

                entity.Property(e => e.AddressRow)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.AddressType)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<ApplicationRoles>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("uc_ApplicationRoles_Name")
                    .IsUnique();

                entity.Property(e => e.Active).HasDefaultValueSql("1");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<Attendants>(entity =>
            {
                entity.HasKey(e => new { e.RegisteredEntryUserId, e.SocialId })
                    .HasName("pk_AttendantsId");

                entity.Property(e => e.NumberOfFriends).HasDefaultValueSql("0");

                entity.HasOne(d => d.RegisteredEntryUser)
                    .WithMany(p => p.Attendants)
                    .HasForeignKey(d => d.RegisteredEntryUserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Attendant__Regis__7C4F7684");

                entity.HasOne(d => d.Social)
                    .WithMany(p => p.Attendants)
                    .HasForeignKey(d => d.SocialId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Attendant__Socia__7D439ABD");
            });

            modelBuilder.Entity<Boats>(entity =>
            {
                entity.HasIndex(e => new { e.SailingNo, e.Type })
                    .HasName("uc_Boats_SailingNo_Type")
                    .IsUnique();

                entity.Property(e => e.Active).HasDefaultValueSql("1");

                entity.Property(e => e.Description).HasColumnType("varchar(255)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<Clubs>(entity =>
            {
                entity.HasIndex(e => new { e.Name, e.Region })
                    .HasName("uc_Clubs_Name_Region")
                    .IsUnique();

                entity.Property(e => e.Active).HasDefaultValueSql("1");

                entity.Property(e => e.Description).HasColumnType("varchar(255)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Homepage)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Logotype).HasColumnType("varchar(100)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnType("varchar(15)");

                entity.Property(e => e.Region)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.RegistrationDate).HasColumnType("date");
            });

            modelBuilder.Entity<CrewMembers>(entity =>
            {
                entity.HasKey(e => new { e.RegisteredEntryUserId, e.TeamId })
                    .HasName("pk_CrewMembers_RegisteredEntryUserId_TeamId");

                entity.HasOne(d => d.RegisteredEntryUser)
                    .WithMany(p => p.CrewMembers)
                    .HasForeignKey(d => d.RegisteredEntryUserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__CrewMembe__Regis__4F7CD00D");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.CrewMembers)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__CrewMembe__TeamI__5070F446");
            });

            modelBuilder.Entity<Entries>(entity =>
            {
                entity.HasIndex(e => e.No)
                    .HasName("uc_Entries_No")
                    .IsUnique();

                entity.Property(e => e.Active).HasDefaultValueSql("1");

                entity.Property(e => e.RegistrationDate).HasColumnType("date");

                entity.HasOne(d => d.Regatta)
                    .WithMany(p => p.Entries)
                    .HasForeignKey(d => d.RegattaId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Entries__Regatta__4222D4EF");

                entity.HasOne(d => d.ResponsibleUser)
                    .WithMany(p => p.Entries)
                    .HasForeignKey(d => d.ResponsibleUserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Entries__Respons__412EB0B6");
            });

            modelBuilder.Entity<Events>(entity =>
            {
                entity.HasIndex(e => new { e.No, e.RegattaId })
                    .HasName("uc_Events_No_RegattaId")
                    .IsUnique();

                entity.Property(e => e.Active).HasDefaultValueSql("1");

                entity.Property(e => e.Description).HasColumnType("varchar(255)");

                entity.Property(e => e.EndLocation)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.Fee).HasDefaultValueSql("0");

                entity.Property(e => e.Notes).HasColumnType("varchar(255)");

                entity.Property(e => e.StartLocation)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.HasOne(d => d.Regatta)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.RegattaId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Events__RegattaI__5441852A");
            });

            modelBuilder.Entity<Races>(entity =>
            {
                entity.Property(e => e.Active).HasDefaultValueSql("1");

                entity.Property(e => e.Classification)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.EndLocation)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Races)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Races__EventId__59FA5E80");

                entity.HasOne(d => d.Regatta)
                    .WithMany(p => p.Races)
                    .HasForeignKey(d => d.RegattaId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Races__RegattaId__59063A47");
            });

            modelBuilder.Entity<Regattas>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("uc_Regattas_Name")
                    .IsUnique();

                entity.Property(e => e.Active).HasDefaultValueSql("1");

                entity.Property(e => e.Description).HasColumnType("varchar(255)");

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.Fee).HasDefaultValueSql("0");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Notes).HasColumnType("varchar(255)");

                entity.Property(e => e.StartTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<RegisteredEntryUsers>(entity =>
            {
                entity.HasIndex(e => new { e.UserId, e.EntryId })
                    .HasName("uc_RegisteredEntryUserId_UserId_EntryId")
                    .IsUnique();

                entity.HasOne(d => d.Entry)
                    .WithMany(p => p.RegisteredEntryUsers)
                    .HasForeignKey(d => d.EntryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Registere__Entry__47DBAE45");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.RegisteredEntryUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Registere__UserI__46E78A0C");
            });

            modelBuilder.Entity<Results>(entity =>
            {
                entity.HasIndex(e => new { e.Rank, e.RaceId })
                    .HasName("uc_Results_Rank_Raceid")
                    .IsUnique();

                entity.Property(e => e.Active).HasDefaultValueSql("1");

                entity.Property(e => e.ActualTime).HasColumnType("datetime");

                entity.Property(e => e.CalculatedTime).HasColumnType("datetime");

                entity.Property(e => e.Remark).HasColumnType("varchar(3)");

                entity.HasOne(d => d.Entry)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.EntryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Results__EntryId__787EE5A0");

                entity.HasOne(d => d.Race)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.RaceId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Results__RaceId__778AC167");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasIndex(e => e.Type)
                    .HasName("uc_Roles_Type")
                    .IsUnique();

                entity.Property(e => e.Active).HasDefaultValueSql("1");

                entity.Property(e => e.ContactPhone).HasColumnType("varchar(15)");

                entity.Property(e => e.Description).HasColumnType("varchar(255)");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<Socials>(entity =>
            {
                entity.HasIndex(e => new { e.RegattaId, e.EventId })
                    .HasName("uc_Socials_EventId_RegattaId")
                    .IsUnique();

                entity.Property(e => e.Active).HasDefaultValueSql("1");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Socials)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Socials__EventId__5FB337D6");

                entity.HasOne(d => d.Regatta)
                    .WithMany(p => p.Socials)
                    .HasForeignKey(d => d.RegattaId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Socials__Regatta__5EBF139D");

                entity.HasOne(d => d.RegisteredEntry)
                    .WithMany(p => p.Socials)
                    .HasForeignKey(d => d.RegisteredEntryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Socials__Registe__60A75C0F");
            });

            modelBuilder.Entity<Teams>(entity =>
            {
                entity.HasIndex(e => new { e.Name, e.EntryId })
                    .HasName("uc_Teams_Name_EntryId_BoatId")
                    .IsUnique();

                entity.Property(e => e.Active).HasDefaultValueSql("1");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.HasOne(d => d.Entry)
                    .WithMany(p => p.Teams)
                    .HasForeignKey(d => d.EntryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Teams__EntryId__4BAC3F29");
            });

            modelBuilder.Entity<UserApplicationRoles>(entity =>
            {
                entity.HasKey(e => new { e.ApplicationRoleId, e.UserId })
                    .HasName("pk_UserApplicationRoles_ApplicationRoleId_UserId");

                entity.HasOne(d => d.ApplicationRole)
                    .WithMany(p => p.UserApplicationRoles)
                    .HasForeignKey(d => d.ApplicationRoleId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__UserAppli__Appli__3C69FB99");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserApplicationRoles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__UserAppli__UserI__3D5E1FD2");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("uc_Users_Email")
                    .IsUnique();

                entity.Property(e => e.Active).HasDefaultValueSql("1");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.IceFirstName)
                    .HasColumnName("ICE_FirstName")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.IceLastName)
                    .HasColumnName("ICE_LastName")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.IcePhone)
                    .HasColumnName("ICE_Phone")
                    .HasColumnType("varchar(15)");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnType("varchar(15)");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Users__AddressId__2C3393D0");
            });
        }
    }
}
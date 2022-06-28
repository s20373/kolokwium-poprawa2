using Microsoft.EntityFrameworkCore;

namespace kolokwium_poprawa.Models
{
    public class MainDbContext : DbContext
    {

        protected MainDbContext()
        {

        }

        public MainDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<File> File { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<Membership> Membership { get; set; }
        public DbSet<Organization> Organization { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<File>(f =>
            {
                f.HasKey(e => e.FileID);
                f.HasKey(e => e.TeamID);
                f.Property(e => e.FileName).IsRequired().HasMaxLength(100);
                f.Property(e => e.FileExtension).IsRequired().HasMaxLength(4);
                f.Property(e => e.FileSize).IsRequired();

                f.HasOne(e => e.Team).WithMany(e => e.Files).HasForeignKey(e => e.TeamID);

                f.HasData(
                    new File { FileID = 1, TeamID = 1, FileName = "filename1", FileExtension = "pdf", FileSize = 128 },
                    new File { FileID = 2, TeamID = 2, FileName = "filename2", FileExtension = "docx", FileSize = 256 }
                );

            });

            modelBuilder.Entity<Team>(t =>
            {
                t.HasKey(e => e.TeamID);
                t.Property(e => e.TeamName).IsRequired().HasMaxLength(50);
                t.Property(e => e.TeamDescription).HasMaxLength(500);

                t.HasOne(e => e.Organization).WithMany(e => e.Teams).HasForeignKey(e => e.OrganizationID);

                t.HasData(
                    new Team { TeamID = 1, TeamName = "TEAM ONE", TeamDescription = "TEAM ONE DESCRIPTION", OrganizationID = 1 },
                    new Team { TeamID = 2, TeamName = "TEAM TWO", OrganizationID = 2 }
                );
            });

            modelBuilder.Entity<Organization>(o =>
            {
                o.HasKey(e => e.OrganizationID);
                o.Property(e => e.OrganizationName).IsRequired().HasMaxLength(100);
                o.Property(e => e.OrganizationDomain).IsRequired().HasMaxLength(50);

                o.HasData(
                    new Organization { OrganizationID = 1, OrganizationName = "Organization name 1", OrganizationDomain = "Organization domain 1" },
                    new Organization { OrganizationID = 2, OrganizationName = "Organization name 2", OrganizationDomain = "Organization domain 2" }
                );
            });

            modelBuilder.Entity<Member>(m =>
            {
                m.HasKey(e => e.MemberID);
                m.Property(e => e.MemberName).IsRequired().HasMaxLength(20);
                m.Property(e => e.MemberSurname).IsRequired().HasMaxLength(50);
                m.Property(e => e.MemberNickName).HasMaxLength(20);

                m.HasOne(e => e.Organization).WithMany(e => e.Members).HasForeignKey(e => e.OrganizationID).OnDelete(DeleteBehavior.SetNull);

                m.HasData(
                    new Member { MemberID = 1, MemberName = "Jan", MemberSurname = "Kowalski", MemberNickName = "jkowalski", OrganizationID = 1 },
                    new Member { MemberID = 2, MemberName = "Maciej", MemberSurname = "Nowak", OrganizationID = 2 }
                );
            });

            modelBuilder.Entity<Membership>(ms =>
            {
                ms.HasKey(e => e.MemberID);
                ms.HasKey(e => e.TeamID);
                ms.Property(e => e.MembershipDate);

                ms.HasOne(e => e.Team).WithMany(e => e.Memberships).HasForeignKey(e => e.TeamID).OnDelete(DeleteBehavior.SetNull);
                ms.HasOne(e => e.Member).WithMany(e => e.Memberships).HasForeignKey(e => e.MemberID).OnDelete(DeleteBehavior.SetNull);

                ms.HasData(
                    new Membership { MemberID = 1, TeamID = 1, MembershipDate = DateTime.Parse("1989-01-25") },
                    new Membership { MemberID = 2, TeamID = 2, MembershipDate = DateTime.Parse("1999-06-12") }
                );
            });
        }

    }
}

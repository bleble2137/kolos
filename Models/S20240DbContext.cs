using kolos.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace kolos.Models
{
    public class S20240DbContext : DbContext
    {
        public S20240DbContext()
        {
        }

        public S20240DbContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<File> File { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<Membership> Membership { get; set; }
        public DbSet<Organization> Organization { get; set; }
        public DbSet<Team> Team { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<File>(p =>
            {
                p.HasKey(e => new { e.FileID, e.TeamID });
                p.Property(e => e.FileName).IsRequired().HasMaxLength(100);
                p.Property(e => e.FileExtension).IsRequired().HasMaxLength(4);
                p.Property(e => e.FileExtension).IsRequired().HasMaxLength(4);
                p.Property(e => e.FileSize).IsRequired();
                p.HasOne(e => e.Team).WithMany(e => e.Files).HasForeignKey(e => e.TeamID);
                p.HasData(
                    new File { FileID = 1, TeamID = 1, FileName = "firstFileOnTheList", FileExtension = "jpg", FileSize = 512 }
                    );
            });

            modelBuilder.Entity<Member>(p =>
            {
                p.HasKey(e => e.MemberID);
                p.Property(e => e.MemberName).IsRequired().HasMaxLength(20);
                p.Property(e => e.MemberSurname).IsRequired().HasMaxLength(50);
                p.Property(e => e.MemberNickName).IsRequired().HasMaxLength(20);
                p.HasOne(e => e.Organization).WithMany(e => e.Members).HasForeignKey(e => e.OrganizationID);
                p.HasData(
                    new Member { MemberID = 1, OrganizationID = 1, MemberName = "Bill", MemberSurname = "The", MemberNickName = "Franz Mauer" }
                    );
            });

            modelBuilder.Entity<Membership>(p =>
            {
                p.HasKey(e => new { e.MemberID, e.TeamID });
                p.Property(e => e.MembershipDate).IsRequired();
                p.HasOne(e => e.Team).WithMany(e => e.Memberships).HasForeignKey(e => e.TeamID);
                p.HasOne(e => e.Member).WithMany(e => e.Memberships).HasForeignKey(e => e.MemberID);
                p.HasData(
                    new Membership { MemberID = 1, TeamID = 1, MembershipDate = DateTime.Parse("2021-06-08") }
                    ); ;
            });

            modelBuilder.Entity<Organization>(p =>
            {
                p.HasKey(e => e.OrganizationID);
                p.Property(e => e.OrganizationName).IsRequired().HasMaxLength(100);
                p.Property(e => e.OrganizationDomain).IsRequired().HasMaxLength(50);
                p.HasData(
                    new Organization { OrganizationID = 1, OrganizationName = "Super Team Organization", OrganizationDomain = "Los Domainos" }
                    );
            });

            modelBuilder.Entity<Team>(p =>
            {
                p.HasKey(e => e.TeamID);
                p.Property(e => e.TeamName).IsRequired().HasMaxLength(50);
                p.Property(e => e.TeamDescription).IsRequired().HasMaxLength(500);
                p.HasOne(e => e.Organization).WithMany(e => e.Teams).HasForeignKey(e => e.OrganizationID);
                p.HasData(
                    new Team { TeamID = 1, OrganizationID = 1, TeamName = "firstTeam", TeamDescription = "Interesting description" }
                    );
            });
            
        }
    }
}

using Core.Security.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Contexts
{
    public class AppDbContext:DbContext
    {
        protected IConfiguration? Configuration { get; set; }
        public DbSet<ProgrammingLanguage> programmingLanguages { get; set; }

        public DbSet<Technology> technologies { get; set; }
        public DbSet<User> users{ get; set; }

        public AppDbContext(DbContextOptions  dbContextOptions ,IConfiguration configuration ):base(dbContextOptions)  
        {
            Configuration = configuration;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgrammingLanguage>(a =>
            {
                a.ToTable("ProgrammingLanguages").HasKey(l => l.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.HasMany(p => p.Technologies);
            });
            modelBuilder.Entity<Technology>(a =>
            {
                a.ToTable("Technologies").HasKey(t => t.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.Property(p => p.ProgrammingLanguageId).HasColumnName("ProgrammingLanguageId");
                a.HasOne(p => p.ProgrammingLanguage);
            });




            modelBuilder.Entity<User>(a =>
            {
                a.ToTable("Users").HasKey(t => t.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.FirstName).HasColumnName("FirstName");
                a.Property(p => p.LastName).HasColumnName("LastName");
                a.Property(p => p.Status).HasColumnName("Status");
                a.Property(p => p.GithubAddress).HasColumnName("GithubAddress");
                a.Property(p => p.PasswordHash).HasColumnName("PasswordHash");
                a.Property(p => p.PasswordSalt).HasColumnName("PasswordSalt");
                a.Property(p => p.Email).HasColumnName("Email");
            });





            ProgrammingLanguage[] programmingLanguageEntitySeeds = { new(1, "C#"), new(2, "Java") , new(3,"Python") };
            modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguageEntitySeeds);

            Technology[] technologyEntitySeeds = { new(1 ,  "Asp.Net" , 1), new(2, "Spring" , 2), new(3, "Django" , 3) };
            modelBuilder.Entity<Technology>().HasData(technologyEntitySeeds);

        }
    }
}

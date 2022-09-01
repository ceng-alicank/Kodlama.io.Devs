using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class AppDbContext:DbContext
    {
        protected IConfiguration? Configuration { get; set; }
        public DbSet<ProgrammingLanguage> programmingLanguages { get; set; }

        public AppDbContext(DbContextOptions  dbContextOptions ,IConfiguration configuration ):base(dbContextOptions)  
        {
            Configuration = configuration;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

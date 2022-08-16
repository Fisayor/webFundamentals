using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyDataBase.Entity
{
    public class DatabaseCoreContext : DbContext
    {

        public DatabaseCoreContext(){


        }

        public DatabaseCoreContext(DbContextOptions<DatabaseCoreContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location))
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            IConfiguration config = builder.Build();
            var connection = config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connection);
        }

        public DbSet<User> Users { get; set; }

        //mapping it
        protected override void OnModelCreating(ModelBuilder modelBuilder) { 
            //whatever thing that exist in the Users table, use it in the User table
        modelBuilder.Entity<User>().ToTable("Users");
        }
    }
}

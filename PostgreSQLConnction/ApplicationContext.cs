using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_and_Regiser.PostgreSQLConnction
{
    class ApplicationContext : DbContext
    {
        public DbSet<User> users { get; set; }
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql
                (
                    "Host = localhost;" +
                    "Port = 5432;" +
                    "Database = Userdb;" +
                    "User ID = postgres;" +
                    "Password = 123123123"
                );
        }
    }
}

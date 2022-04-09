using Login_and_Regiser.UsersFolder;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;

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
            optionsBuilder.UseMySql(
                "server=localhost;user=root;password=root;database=usersdb;",
                new MySqlServerVersion(new Version(8, 0, 11))
            );
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StudentObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AppDBContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder!.IsConfigured)
            {
                var config = new ConfigurationBuilder().AddEnvironmentVariables().Build();
            var connectionString = config["MYSQLConnection"];
                if (string.IsNullOrEmpty(connectionString)) {
                    throw new Exception("Environment variable MYSQLConnection not set!");
                }
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }
        }
    }
}

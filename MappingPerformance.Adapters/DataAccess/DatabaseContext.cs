using MappingPerformance.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MappingPerformance.Adapters.DataAccess
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Employee> Employee { get; set; }

        public DatabaseContext()
        {

        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
    }
}

using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET.D3.Examples.Model
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Company>    Companies    { get; set; }
        public DbSet<Models.Subsidiary> Subsidiaries { get; set; }
        public DbSet<Models.Department> Departments  { get; set; }
    }

    public class Models
    {
        public class Reference
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class Company : Reference
        {
            public List<Subsidiary> Children { get; set; }
        }

        public class Subsidiary : Reference
        {
            public Company Parent { get; set; }
            public List<Department> Children { get; set; }
        }

        public class Department : Reference
        {
            public Subsidiary Parent { get; set; }
        }
    }
}
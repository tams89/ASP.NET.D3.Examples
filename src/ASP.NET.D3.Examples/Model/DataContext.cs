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
        public class Company
        {
            public int CompanyId { get; set; }
            public string Name { get; set; }

            public List<Subsidiary> Children { get; set; }
        }

        public class Subsidiary
        {
            public int SubsidiaryId { get; set; }
            public string Name { get; set; }

            public Company Parent { get; set; }
            public List<Department> Children { get; set; }
        }

        public class Department
        {
            public int DepartmentId { get; set; }
            public string Name { get; set; }

            public Subsidiary Parent { get; set; }
        }
    }
}
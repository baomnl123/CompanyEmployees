using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;

namespace Repository;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions options)
        : base(options) { }

    public DbSet<Company>? Companies { get; set; }
    public DbSet<Employee>? Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Company[] companies = CompanyConfigration.InitializeDataForCompanies();
        Employee[] employees = EmployeeConfiguration.InitializeDataForEmployees(companies);

        modelBuilder.Entity<Company>().HasData(companies);
        modelBuilder.Entity<Employee>().HasData(employees);
    }
}

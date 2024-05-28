using Bogus;
using Entities.Models;

namespace Repository.Configuration;

public static class EmployeeConfiguration
{
    public static Employee[] InitializeDataForEmployees(Company[] companies)
    {
        return
        [
            .. new Faker<Employee>()
                .UseSeed(1)
                .RuleFor(employee => employee.Id, f => f.Random.Guid())
                .RuleFor(employee => employee.Name, f => f.Name.FullName())
                .RuleFor(employee => employee.Age, f => f.Random.Int(18, 60))
                .RuleFor(employee => employee.Position, f => f.Name.JobTitle())
                .RuleFor(employee => employee.CompanyId, f => f.PickRandom(companies).Id)
                .Generate(50)
        ];
    }
}

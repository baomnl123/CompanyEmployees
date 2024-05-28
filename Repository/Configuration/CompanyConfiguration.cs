using Bogus;
using Entities.Models;

namespace Repository.Configuration;

public static class CompanyConfigration
{
    public static Company[] InitializeDataForCompanies()
    {
        return
        [
            .. new Faker<Company>()
                .UseSeed(1)
                .RuleFor(company => company.Id, f => f.Random.Guid())
                .RuleFor(company => company.Name, f => f.Company.CompanyName())
                .RuleFor(company => company.Address, f => f.Address.StreetAddress())
                .RuleFor(company => company.Country, f => f.Address.Country())
                .Generate(50)
        ];
    }
}

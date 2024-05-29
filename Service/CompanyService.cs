using Contracts;
using Service.Contracts;

namespace Service;

internal sealed class CompanyService(IRepositoryManager repositoryManager, ILoggerManager logger)
    : ICompanyService
{
    private readonly IRepositoryManager _repositoryManager = repositoryManager;
    private readonly ILoggerManager _logger = logger;
}

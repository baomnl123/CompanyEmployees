using Contracts;
using Service.Contracts;

namespace Service;

internal sealed class EmployeeService(IRepositoryManager repositoryManager, ILoggerManager logger)
    : IEmployeeService
{
    private readonly IRepositoryManager _repositoryManager = repositoryManager;
    private readonly ILoggerManager _logger = logger;
}

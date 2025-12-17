using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Infrastructure.DataAccess;
using CashFlow.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        AddRepositories(services);
        AddDbContext(services);
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IExpenseRepository, ExpensesRepository>();
    }
    private static void AddDbContext(IServiceCollection services)
    {
        services.AddDbContext<CashFlowDbContext>();
    }
}

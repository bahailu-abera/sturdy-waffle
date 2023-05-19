using App.Application.Contracts.Persistence;
using App.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App.Persistence;

public static class PersistenceServicesRegistration
{
    public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("AppConnectionString")));
        
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ITaskRepository, TaskRepository>();
        services.AddScoped<IChecklistRepository, ChecklistRepository>();

        return services;
    }
}

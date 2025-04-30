using ASDesafioFinal.Application.Products.Interfaces;
using ASDesafioFinal.Application.Products.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ASDesafioFinal.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IWriteProductService, WriteProductService>();
        services.AddScoped<IReadProductService, ReadProductService>();

        return services;
    }
}

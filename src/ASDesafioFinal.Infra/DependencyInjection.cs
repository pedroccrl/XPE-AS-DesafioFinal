using ASDesafioFinal.Domain.Products.Repositories;
using ASDesafioFinal.Infra.Data.EF;
using ASDesafioFinal.Infra.Data.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ASDesafioFinal.Infra;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("SqlServerConnection");

        services.AddDbContext<DesafioFinalDbContext>(options =>
            options.UseSqlServer(connectionString, act => act.MigrationsAssembly(typeof(DependencyInjection).Assembly)));

        services.AddScoped<IProductRepository, EFProductRepository>();

        var scope = services.BuildServiceProvider().CreateScope();

        using (var context = scope.ServiceProvider.GetRequiredService<DesafioFinalDbContext>())
        {
            context.Database.Migrate();
        }
    }
}

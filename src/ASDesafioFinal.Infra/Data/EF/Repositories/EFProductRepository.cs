using ASDesafioFinal.Domain.Products.Entities;
using ASDesafioFinal.Domain.Products.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ASDesafioFinal.Infra.Data.EF.Repositories;

public class EFProductRepository(DesafioFinalDbContext dbContext) : EFRepository<Product>(dbContext), IProductRepository
{
    public Task<int> CountAsync()
    {
        return dbContext.Products.CountAsync();
    }

    public async Task<IEnumerable<Product>> FindAllAsync()
    {
        return await dbContext.Products.ToListAsync();
    }

    public async Task<Product?> FindByIdAsync(Guid id)
    {
        var product = await dbContext.Products
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        return product;
    }

    public async Task<IEnumerable<Product>> FindByNameAsync(string name)
    {
        return await dbContext.Products
            .AsNoTracking()
            .Where(x => x.Name.Contains(name))
            .ToListAsync();
    }
}

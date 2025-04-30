using ASDesafioFinal.Domain.Common;
using ASDesafioFinal.Domain.Products.Entities;

namespace ASDesafioFinal.Domain.Products.Repositories;

public interface IProductRepository : IRepository<Product>
{
    Task<int> CountAsync();
    Task<IEnumerable<Product>> FindAllAsync();
    Task<Product?> FindByIdAsync(Guid id);
    Task<IEnumerable<Product>> FindByNameAsync(string name);
}

using ASDesafioFinal.Application.Products.Dtos;

namespace ASDesafioFinal.Application.Products.Interfaces;

public interface IReadProductService
{
    Task<int> CountAsync();
    Task<IEnumerable<ProductItemDto>> FindAllAsync();
    Task<ProductItemDto?> FindByIdAsync(Guid id);
    Task<IEnumerable<ProductItemDto>> FindByNameAsync(string name);
}

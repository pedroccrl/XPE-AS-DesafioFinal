using ASDesafioFinal.Application.Products.Dtos;
using ASDesafioFinal.Domain.Products.Entities;

namespace ASDesafioFinal.Application.Products.Interfaces;

public interface IWriteProductService
{
    Task<Product> CreateProductAsync(CreateProductDto createProductDto);
    Task<(bool, Product?)> UpdateProductAsync(UpdateProductDto updateProductDto);
    Task<bool> DeleteProductAsync(Guid id);
}

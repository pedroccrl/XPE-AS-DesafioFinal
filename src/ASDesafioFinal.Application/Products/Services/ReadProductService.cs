using ASDesafioFinal.Application.Products.Dtos;
using ASDesafioFinal.Application.Products.Interfaces;
using ASDesafioFinal.Domain.Products.Entities;
using ASDesafioFinal.Domain.Products.Repositories;

namespace ASDesafioFinal.Application.Products.Services;

internal class ReadProductService(IProductRepository productRepository) : IReadProductService
{
    public Task<int> CountAsync()
    {
        return productRepository.CountAsync();
    }

    public async Task<IEnumerable<ProductItemDto>> FindAllAsync()
    {
        var products = await productRepository.FindAllAsync();

        return products.Select(MapToDto);
    }

    public async Task<ProductItemDto?> FindByIdAsync(Guid id)
    {
        var product = await productRepository.FindByIdAsync(id);
        if (product is null)
        {
            return null;
        }

        return MapToDto(product);
    }

    public async Task<IEnumerable<ProductItemDto>> FindByNameAsync(string name)
    {
        var products = await productRepository.FindByNameAsync(name);

        return products.Select(MapToDto);
    }

    private ProductItemDto MapToDto(Product product)
    {
        return new ProductItemDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.PriceInCents,
        };
    }
}

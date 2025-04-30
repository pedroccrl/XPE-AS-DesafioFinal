using ASDesafioFinal.Application.Products.Dtos;
using ASDesafioFinal.Application.Products.Interfaces;
using ASDesafioFinal.Domain.Products.Entities;
using ASDesafioFinal.Domain.Products.Repositories;

namespace ASDesafioFinal.Application.Products.Services;

public class WriteProductService(IProductRepository productRepository) : IWriteProductService
{
    public async Task<Product> CreateProductAsync(CreateProductDto createProductDto)
    {
        var product = new Product(createProductDto.Name, createProductDto.Price, createProductDto.Description);

        await productRepository.CreateAsync(product);

        return product;
    }

    public async Task<bool> DeleteProductAsync(Guid id)
    {
        return await productRepository.DeleteAsync(id);
    }

    public async Task<(bool, Product?)> UpdateProductAsync(UpdateProductDto updateProductDto)
    {
        var product = await productRepository.FindByIdAsync(updateProductDto.Id);
        if (product is null)
        {
            return (false, null);
        }

        product.Update(updateProductDto.Name, updateProductDto.Price, updateProductDto.Description);

        await productRepository.UpdateAsync(product);

        return (true, product);
    }
}

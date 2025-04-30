namespace ASDesafioFinal.Application.Products.Dtos;

public record UpdateProductDto(Guid Id, string Name, uint Price, string? Description);

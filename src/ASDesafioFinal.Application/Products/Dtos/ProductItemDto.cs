namespace ASDesafioFinal.Application.Products.Dtos;

public class ProductItemDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public uint Price { get; set; }
    public DateTime CreatedAt { get; set; }
}

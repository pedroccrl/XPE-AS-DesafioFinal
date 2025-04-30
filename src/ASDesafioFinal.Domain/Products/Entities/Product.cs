using ASDesafioFinal.Domain.Common;

namespace ASDesafioFinal.Domain.Products.Entities;

public class Product : Entity
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public uint PriceInCents { get; set; }

    private Product() { }

    public Product(string name, uint price, string? description = null)
    {
        Name = name;
        Description = description;
        PriceInCents = price;
    }

    public void Update(string name, uint price, string? description)
    {
        Name = name;
        PriceInCents = price;
        Description ??= description;
        UpdatedAt = DateTime.UtcNow;
    }
}

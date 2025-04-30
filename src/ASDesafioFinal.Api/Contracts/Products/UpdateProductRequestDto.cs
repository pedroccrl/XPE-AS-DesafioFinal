namespace ASDesafioFinal.Api.Contracts.Products;

public class UpdateProductRequestDto
{
    /// <summary>
    /// Nome do produto
    /// </summary>
    public string Nome { get; set; } = null!;

    /// <summary>
    /// Preço do produto em centavos
    /// </summary>
    public uint Preco { get; set; }

    /// <summary>
    /// Descrição do produto
    /// </summary>
    public string? Descricao { get; set; }
}

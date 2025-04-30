namespace ASDesafioFinal.Api.Contracts.Products;

public class CreateProductRequestDto
{
    /// <summary>
    /// Nome do produto
    /// </summary>
    /// <example>Produto Teste</example>
    public string Nome { get; set; } = null!;

    /// <summary>
    /// Preço do produto em centavos
    /// </summary>
    /// <example>1000</example>
    public uint Preco { get; set; }

    /// <summary>
    /// Descrição do produto
    /// </summary>
    /// <example>Produto de teste para o desafio</example>
    public string? Descricao { get; set; }
}

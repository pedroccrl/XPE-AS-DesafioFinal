using ASDesafioFinal.Api.Contracts.Products;
using ASDesafioFinal.Application.Products.Dtos;
using ASDesafioFinal.Application.Products.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASDesafioFinal.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdutosController(IReadProductService readProductService, IWriteProductService writeProductService) : ControllerBase
{
    /// <summary>
    /// Cria um novo produto.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductRequestDto request)
    {
        var product = await writeProductService
            .CreateProductAsync(new CreateProductDto(
                request.Nome,
                request.Preco,
                request.Descricao));

        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }

    /// <summary>
    /// Retorna todos os produtos cadastrados.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await readProductService.FindAllAsync();
        return Ok(products);
    }

    /// <summary>
    /// Retorna o produto com o id informado.
    /// </summary>
    /// <param name="id">id</param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var product = await readProductService.FindByIdAsync(id);
        if (product == null)
            return NotFound();

        return Ok(product);
    }

    /// <summary>
    /// Atualiza o produto com o id informado.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProductRequestDto request)
    {
        var (success, product) = await writeProductService
            .UpdateProductAsync(new UpdateProductDto(
                id,
                request.Nome,
                request.Preco,
                request.Descricao));

        if (!success)
            return NotFound();

        return Ok(product);
    }

    /// <summary>
    /// Deleta o produto com o id informado.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var success = await writeProductService.DeleteProductAsync(id);
        if (!success)
            return NotFound();

        return NoContent();
    }

    /// <summary>
    /// Retorna os produtos com o nome informado.
    /// </summary>
    /// <param name="nome"></param>
    /// <returns></returns>
    [HttpGet("nome/{nome}")]
    public async Task<IActionResult> GetByName(string nome)
    {
        var product = await readProductService.FindByNameAsync(nome);

        return Ok(product);
    }

    /// <summary>
    /// Retorna o total de produtos cadastrados.
    /// </summary>
    /// <returns></returns>
    [HttpGet("contar")]
    public async Task<IActionResult> Count()
    {
        var count = await readProductService.CountAsync();
        return Ok(count);
    }
}

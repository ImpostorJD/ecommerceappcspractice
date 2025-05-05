using Microsoft.AspNetCore.Mvc;
using Shared.Middleware;

namespace Catalog.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CatalogController(ICatalogService catalogService) : ControllerBase
{
    private readonly ICatalogService _catalogService = catalogService;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _catalogService.GetAllAsync();
        if (products == null || !products.Any())
        {
            throw new NotFoundException("No products found.");
        }
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new BadRequestException("Invalid product ID.");
        }

        var product = await _catalogService.GetByIdAsync(id);
        if (product == null)
        {
            throw new NotFoundException($"Product with ID {id} not found.");
        }
        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Product product)
    {
        if (product == null)
        {
            throw new BadRequestException("Product data is required.");
        }

        var created = await _catalogService.CreateAsync(product);
        if (!created)
        {
            throw new BadRequestException("Product creation failed.");
        }

        return NoContent(); 
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] Product product)
    {
        if (id == Guid.Empty || product == null)
        {
            throw new BadRequestException("Invalid product ID or data.");
        }

        var updated = await _catalogService.UpdateAsync(id, product);
        if (!updated)
        {
            throw new NotFoundException($"Product with ID {id} not found.");
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new BadRequestException("Invalid product ID.");
        }

        var deleted = await _catalogService.DeleteAsync(id);
        if (!deleted)
        {
            throw new NotFoundException($"Product with ID {id} not found.");
        }

        return NoContent(); 
    }

}

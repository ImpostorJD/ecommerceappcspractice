using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CatalogController : ControllerBase
{
    private readonly CatalogService _catalogService;

    public CatalogController(CatalogService catalogService){
        _catalogService = catalogService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _catalogService.GetAllAsync();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var product = await _catalogService.GetByIdAsync(id);
        if (product == null)
            return Ok(product);
        else
            return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Product product)
    {
        var created = await _catalogService.CreateAsync(product);
        if (created)
            return Created();   
        else
            return BadRequest("");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] Product product)
    {
        var value = await _catalogService.UpdateAsync(id, product);

        if (value){
            return Ok(value);
        }else{
            return NotFound("");
        }
        
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
         var value = await _catalogService.DeleteAsync(id);

         if(value)
            return Ok();
        else
            return NotFound();

    }
}
using Catalog.Infrastructure;

namespace Catalog.Application;

public class CatalogService(IProductRepository repo) : ICatalogService
{
    private readonly IProductRepository _repo = repo;

    public async Task<Product?> GetByIdAsync(Guid id) 
        => await _repo.GetByIdAsync(id);

    public async Task<bool> CreateAsync(Product product)
    {
        return await _repo.AddAsync(product);
    }

    public async Task<IEnumerable<Product>> GetAllAsync() 
        => await _repo.GetAllAsync();

    public async Task<bool> UpdateAsync(Guid id, Product product)
        => await _repo.UpdateAsync(id, product);
    
    public async Task<bool> DeleteAsync(Guid id)
        => await _repo.DeleteAsync(id);
    
}
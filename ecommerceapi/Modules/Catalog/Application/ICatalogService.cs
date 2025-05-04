using Catalog.Infrastructure;

namespace Catalog.Application;

public interface ICatalogService 
{

    public Task<Product?> GetByIdAsync(Guid id);

    public Task<bool> CreateAsync(Product product);

    public Task<IEnumerable<Product>> GetAllAsync();

    public Task<bool> UpdateAsync(Guid id, Product product);
    
    public Task<bool> DeleteAsync(Guid id);
    
}
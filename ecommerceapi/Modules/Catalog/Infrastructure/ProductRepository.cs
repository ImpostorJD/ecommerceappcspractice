
namespace Catalog.Infrastructure;

public class ProductRepository(CatalogDbContext context) : IProductRepository
{
   
    public async Task<bool> AddAsync(Product model)
    {
        await context.Products.AddAsync(model);
        await context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(Guid id) 
    {
        var existing = await context.Products.FindAsync( id );
        if(existing is null){
           return false;
        }
        context.Products.Remove( existing );
        
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<Product>> GetAllAsync() 
        => await context.Products.ToListAsync();
    

    public async Task<Product?> GetByIdAsync(Guid id) 
        => await context.Products.FindAsync( id );

    public async Task SaveChangesAsync()
     => await context.SaveChangesAsync();

    public async Task<bool> UpdateAsync(Guid id, Product model)
    {
        var existing = await context.Products.FindAsync( id );
        if(existing is null){
            return false;
        }

        existing.Update(model);

        await context.SaveChangesAsync();

        return true;

    }
}
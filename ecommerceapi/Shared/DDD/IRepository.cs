namespace Shared.DDD;

public interface Irepository<T>
where T: IAggregate
{
    
    Task<IEnumerable<T>> GetAllAsync();

    Task<T?>GetByIdAsync(Guid id);

    Task<bool> AddAsync(T model);

    Task SaveChangesAsync();
    
    Task<bool> UpdateAsync(Guid id, T model);

    Task<bool> DeleteAsync(Guid id);
}
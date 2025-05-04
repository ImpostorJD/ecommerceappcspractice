namespace Shared.DDD;

public interface IService<T>
{
    public Task<T?> GetByIdAsync(Guid id);
    public Task<bool> CreateAsync(T model);
    public Task<IEnumerable<T>> GetAllAsync();
    public Task<bool> UpdateAsync(Guid id, T model);
    public Task<bool> DeleteAsync(Guid id);
}
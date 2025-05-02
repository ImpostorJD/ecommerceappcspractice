
namespace Shared.DDD;

//<summary>
// This class is a base class to be used to define metadata of each entity
// </summary
public abstract class Entity<T> : IEntity<T>
{
    required public T Id { get; set; }
    public DateTime? CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? LastModified { get; set; }
    public string? LastModifiedBy { get; set; }
}
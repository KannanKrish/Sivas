namespace Sivas.Data;

public abstract class BaseEntity : IBaseEntity<Guid>
{
    public Guid Id { get; set; }
}
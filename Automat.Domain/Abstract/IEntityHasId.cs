namespace Automat.Domain
{
    public interface IEntityHasId<T> : IEntity
    {
        T Id { get; set; }
    }
}

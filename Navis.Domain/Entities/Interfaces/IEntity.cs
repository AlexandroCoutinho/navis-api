namespace Navis.Domain.Entities.Interfaces
{
    public interface IEntity
    {
        string Id { get; set; }
        bool IsDeleted { get; set; }
    }
}

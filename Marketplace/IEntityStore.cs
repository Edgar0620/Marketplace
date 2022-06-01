using Marketplace.Domain;

namespace Marketplace
{
    public interface IEntityStore
    {
        Task<T> Load<T>(string entityID) where T :Entity;
        Task<T> Save<T>(T entity) where T : Entity;
        Task<bool> Exists<T>(string entityID);
    }
}

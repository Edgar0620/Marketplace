namespace Marketplace
{
    public class RavenDBEntityStore : IEntityStore
    {
        public Task<T> Load<T>(string id)
        {
            throw new NotImplementedException();
        }

        public Task<T> Save<T>(T entity)
        {
            throw new NotImplementedException();
        }
    }
}

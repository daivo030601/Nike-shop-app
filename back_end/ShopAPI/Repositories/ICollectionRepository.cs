using ShopAPI.Data;

namespace ShopAPI.Repositories
{
    public interface ICollectionRepository
    {
        Task<int> InsertCollection(CollectionModel collectionModel);
        Task<List<CollectionModel>> GetCollections();
    }
}

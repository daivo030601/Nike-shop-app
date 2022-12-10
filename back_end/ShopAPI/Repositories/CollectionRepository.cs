using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopAPI.Data;
using ShopAPI.Models;

namespace ShopAPI.Repositories
{
    public class CollectionRepository : ICollectionRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CollectionRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CollectionModel>> GetCollections()
        {
            var collections = await _context.collections!.ToListAsync();
            return _mapper.Map<List<CollectionModel>>(collections);
        }

        public async Task<int> InsertCollection(CollectionModel collectionModel)
        {
            var newCollection = _mapper.Map<Collection>(collectionModel);
            _context.collections.Add(newCollection);
            await _context.SaveChangesAsync();
            return newCollection.CollectionId;
        }
    }
}

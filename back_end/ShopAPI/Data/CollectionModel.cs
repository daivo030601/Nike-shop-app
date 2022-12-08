using ShopAPI.Models;

namespace ShopAPI.Data
{
    public class CollectionModel
    {
        public int CollectionId { get; set; }
        public byte[]? Picture { get; set; } = null;
        public string Name { get; set; } = null;
    }
}

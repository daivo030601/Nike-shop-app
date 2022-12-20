using ShopAPI.Models;

namespace ShopAPI.Data
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string? Name { get; set; } = null;
        public byte[]? Picture { get; set; } = null;
        public float Price { get; set; }
        public float? Discount { get; set; } = 1;
        public int Quantity { get; set; }
        public string? Description { get; set; } = null;
        public string? Variety { get; set; } = null;
        public List<int> ColorsId { get; set; }
        public List<int> SizesId { get; set; }
        public int? CollectionId { get; set; }
        public int? CategoryId { get; set; }
    }
}

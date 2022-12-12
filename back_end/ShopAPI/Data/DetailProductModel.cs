namespace ShopAPI.Data
{
    public class DetailProductModel
    {
        public int ProductId { get; set; }
        public string? Name { get; set; } = null;
        public byte[]? Picture { get; set; } = null;
        public float Price { get; set; }
        public float? Discount { get; set; } = 1;
        public int Quatity { get; set; }
        public string? Description { get; set; } = null;
        public string? Variety { get; set; } = null;
        public List<string>? ColorCode { get; set; }
        public List<string>? SizeName { get; set; }
        public int? CollectionId { get; set; }
        public int? CategoryId { get; set; }
    }
}

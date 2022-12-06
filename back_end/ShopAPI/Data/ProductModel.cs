namespace ShopAPI.Data
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public byte[]? Picture { get; set; }
        public int Price { get; set; }
        public int Category { get; set; }
        public string? Description { get; set; }
        public string[] Color { get; set; }
        public int[] Size { get; set; }
        public string variety { get; set; }
        public int? CollectionId { get; set; }
    }
}

namespace ShopAPI.Models
{
    public class Collection
    {
        public int Id { get; set; }
        public byte[] Picture { get; set; }
        public virtual List<Product> Products { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}

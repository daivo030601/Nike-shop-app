using System.ComponentModel.DataAnnotations.Schema;

namespace ShopAPI.Models
{
    [Table("collection")]

    public class Collection
    {
        public int CollectionId { get; set; }
        public byte[] Picture { get; set; } = null;
        public virtual List<Product> Products { get; set; }
        public string Name { get; set; } = null;
    }
}

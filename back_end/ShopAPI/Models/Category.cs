using System.ComponentModel.DataAnnotations.Schema;

namespace ShopAPI.Models
{
    [Table("category")]

    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = null;
        public string Description { get; set; } = null;
        public byte[] Picture { get; set; } = null;

        public ICollection<Product> Products { get; set;}
    }
}

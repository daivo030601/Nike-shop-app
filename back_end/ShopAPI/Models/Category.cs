using System.ComponentModel.DataAnnotations.Schema;

namespace ShopAPI.Models
{
    [Table("category")]

    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }

        public ICollection<Product> Products { get; set;}
    }
}

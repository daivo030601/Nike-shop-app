using System.ComponentModel.DataAnnotations.Schema;

namespace ShopAPI.Models
{
    [Table("color")]
    public class Color
    {
        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}

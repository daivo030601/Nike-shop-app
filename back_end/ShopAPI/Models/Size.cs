using System.ComponentModel.DataAnnotations.Schema;

namespace ShopAPI.Models
{
    [Table("size")]
    public class Size
    {
        public int SizeId { get; set; }
        public string SizeName { get; set; }
        public int? ProductId { get; set; }
        public Product Product { get; set; }
    }
}

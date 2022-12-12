using System.ComponentModel.DataAnnotations.Schema;

namespace ShopAPI.Models
{
    [Table("sizeProduct")]
    public class SizeProduct
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int SizeId { get; set; }
        public Size Size { get; set; }

    }
}

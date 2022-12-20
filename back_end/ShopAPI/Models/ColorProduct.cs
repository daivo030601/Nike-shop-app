using System.ComponentModel.DataAnnotations.Schema;

namespace ShopAPI.Models
{
    [Table("colorProduct")]
    public class ColorProduct
    {
        public ColorProduct( int ProductId, int ColorId)
        {
            this.ProductId = ProductId;
            this.ColorId = ColorId;
        }
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int ColorId { get; set; }
        public Color Color { get; set; }
    }
}

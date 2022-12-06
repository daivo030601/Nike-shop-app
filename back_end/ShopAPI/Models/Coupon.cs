using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopAPI.Models
{
    [Table("coupon")]
    public class Coupon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Cost { get; set; }
        public DateTime Exp { get; set; }
        public string Key { get; set; }

    }
}

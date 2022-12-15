using System.ComponentModel.DataAnnotations.Schema;

namespace ShopAPI.Models
{
    [Table("recipe")]

    public class Recipe
    {
        public int RecipeId { get; set; }
        public int UserId { get; set; }
        public int CouponId { get; set; } = 0;
        public DateTime RecipeDate { get; set; }

        public User User { get; set; }
        public Coupon Coupon { get; set; }
        public List<RecipeItem> RecipeItems { get; set; }

    }
}

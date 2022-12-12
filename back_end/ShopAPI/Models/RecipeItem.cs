using System.ComponentModel.DataAnnotations.Schema;

namespace ShopAPI.Models
{
    [Table("recipeItem")]

    public class RecipeItem
    {
        public int RecipeId { get; set; }
        public int Quatity { get; set; }
        public int ProductId { get; set; }
        public float Total { get; set; }

        public Product Product { get; set; }
        public Recipe Recipe { get; set; }
    }
}

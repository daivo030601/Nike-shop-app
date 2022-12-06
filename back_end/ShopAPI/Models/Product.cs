using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopAPI.Models
{
    [Table("product")]
    public class Product
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public byte[]? Picture { get; set; }
        public float Price { get; set; }
        public float Discount { get; set; } = 1;
        public int Quatity { get; set; }
        public string? Description { get; set; }
        public string Variety { get; set; }
        public ICollection<Color> Colors { get; set; }
        public ICollection<Size> Sizes { get; set; }
        public ICollection<RecipeItem> RecipeItems { get; set; }


        public int? CollectionId { get; set; }
        public Collection Collection { get; set; }

        public int? CategoryId { get; set; }
        public Category Category { get; set; }

    }
}

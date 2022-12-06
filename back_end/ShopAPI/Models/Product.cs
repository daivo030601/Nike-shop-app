using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopAPI.Models
{
    [Table("product")]
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public byte[]? Picture { get; set; }
        public int Price { get; set; }
        public int Category { get; set; }
        public string? Description { get; set; }
        public virtual List<Color> Colors { get; set; }
        public virtual List<Size> Sizes { get; set; }
        public string variety { get; set; }


        public int? CollectionId { get; set; }
        public Collection Collection { get; set; }

    }
}
